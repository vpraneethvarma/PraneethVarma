namespace GradeProcessor.Tests
{
    public class GradeProcessorTests
    {
        [Fact]
        public void CalculateAverage_ShouldReturnCorrectAverage()
        {
            List<int> grades = new List<int> { 80, 90, 100 };
            double result = GradeProcessor.Core.GradeProcessor.CalculateAverage(grades);
            Assert.Equal(90.0, result, 1);
        }

        [Fact]
        public void CalculateAverage_ShouldHandleEmptyList()
        {
            List<int> grades = new List<int> { };
            Assert.Throws<System.ArgumentException>(() => GradeProcessor.Core.GradeProcessor.CalculateAverage(grades));
        }

        [Fact]
        public void CalculateAverage_ShouldHandle100MGradesIn1Sec()
        {
            List<int> grades = Enumerable.Range(1, 100_000_000).ToList();
            DateTime start = DateTime.UtcNow;
            GradeProcessor.Core.GradeProcessor.CalculateAverage(grades);
            DateTime end = DateTime.UtcNow;
            double elapsed = (end - start).TotalMilliseconds;
            Assert.True(elapsed < 200, $"Execution took {elapsed} ms");
        }

        [Fact]
        public void CalculateMaximumGrade_ShouldReturnCorrectMaximum()
        {
            List<int> grades = new List<int> { 80, 90, 100 };
            int result = GradeProcessor.Core.GradeProcessor.CalculateMaximumGrade(grades);
            Assert.Equal(100, result);
        }

        [Fact]
        public void CalculateMaximumGrade_ShouldHandleEmptyList()
        {
            List<int> grades = new List<int> { };
            Assert.Throws<System.ArgumentException>(() => GradeProcessor.Core.GradeProcessor.CalculateMaximumGrade(grades));
        }

        [Fact]
        public void CalculateMedianGrade_ShouldReturnCorrectMedian()
        {
            List<int> grades = new List<int> { 80, 90, 100 };
            double result = GradeProcessor.Core.GradeProcessor.CalculateMedianGrade(grades);
            Assert.Equal(90.0, result, 1);
        }

        [Fact]
        public void CalculateMedianGrade_ShouldReturnCorrectMedianForEvenNumberOfGrades()
        {
            List<int> grades = new List<int> { 80, 90, 100, 110 };
            double result = GradeProcessor.Core.GradeProcessor.CalculateMedianGrade(grades);
            Assert.Equal(95.0, result, 1); // (90 + 100) / 2 = 95
        }

        [Fact]
        public void CalculateMedianGrade_ShouldHandleEmptyList()
        {
            List<int> grades = new List<int> { };
            Assert.Throws<System.ArgumentException>(() => GradeProcessor.Core.GradeProcessor.CalculateMedianGrade(grades));
        }

    }
}
