Param(
	[Parameter(Mandatory=$true)] [string] $targetPath,
	[Parameter(Mandatory=$true)] [string] $configuration,
	[string] $projectNames
)

function Get-PathParts([string] $targetPath) {
	$separator = ([IO.Path]::DirectorySeparatorChar)
	$isTargetRuntimeFound = $false
	$prev = 0
	$curr = -1

	$basePath = ""
	$targetRuntime = ""
	for ($i = 0; $i -lt $targetPath.Length; $i++) {
		if ($targetPath[$i] -ne $separator) {
			continue
		}

		$prev = $curr + 1
		$curr = $i

		$pathSegment = $targetPath.Substring($prev, $curr - $prev)
		
		if ($pathSegment -eq "tests" -Or $pathSegment -eq "src") {
			$basePath = $targetPath.Substring(0, $prev)
		} elseif ($pathSegment -eq $configuration) {
			$isTargetRuntimeFound = $true
		} elseif ($isTargetRuntimeFound -eq $true) {
			$targetRuntime = $pathSegment
			$isTargetRuntimeFound = $false
		}
	}

	return $basePath, $targetRuntime
}

$projects = $projectNames.Split(",")
$basePath, $targetRuntime = Get-PathParts -targetPath $targetPath

$sb = [System.Text.StringBuilder]::new()
[void]$sb.AppendFormat("babel ""{0}"" ``@", $targetPath)
for ($i = 0; $i -lt $projects.Count; $i++) {
	$projectName = $projects[$i]
	$projectPath = [IO.Path]::Combine($basePath, "src", $projectName, "bin", $configuration, $targetRuntime, "$projectName.dll.map.xml")
	[void]$sb.AppendFormat(" --mapin ""{0}""", $projectPath)
}
[void]$sb.AppendFormat(" --output ""{0}""", $targetPath)
$command = $sb.ToString()

Write-Host $command
Invoke-Expression $command
exit $LASTEXITCODE
