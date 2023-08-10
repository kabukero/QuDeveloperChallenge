using BenchmarkDotNet.Running;
using BenchmarkingTestingApp;

var summary = BenchmarkRunner.Run<BenchmarkingProgram>();
