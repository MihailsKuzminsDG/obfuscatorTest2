global using Dayton.Connection.Sx;
global using FluentAssertions;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Moq;
global using Moq.Microsoft.Configuration;
global using Xunit;
global using Xunit.Extensions.Ordering;

[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]
 