using System;

namespace Highlight.API.Tests.Constants
{
    internal class TestDataPaths
    {
        public static string ActualDataPrefix = AppDomain.CurrentDomain.BaseDirectory + @"../../Test Data/actualData_";
        public static string FailPrefix = AppDomain.CurrentDomain.BaseDirectory + @"../../Test Failures/differences_";
        public static string ArchivePrefix = AppDomain.CurrentDomain.BaseDirectory + @"../../Test Archive/differences_";
        public static string DetailsPageDataByDay = AppDomain.CurrentDomain.BaseDirectory + @"../../Test Data/testData_ExpDetails.txt";
    }
}