using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Xunit;
using Xunit.Abstractions;

namespace Lab2.Tests;

public class EducationalCourseConstructorTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public EducationalCourseConstructorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Unsuccessful_Lab_Update_Non_Author()
    {
        var arnold = new User(new UserName("Arnold"));
        var bob = new User(new UserName("Bob"));

        Laboratory lab1 = new(
            new ElementName("Lab-1"),
            new Description("Create Train System"),
            new Criteries("-20% after deadline"),
            new Grades(20),
            arnold);

        LabResults result = lab1.Update(bob, new Description("Create Train System"));

        var answer = result as LabResults.UnAuthorizedAccessToLab;
        Assert.NotNull(answer);
        Assert.True(result is LabResults.UnAuthorizedAccessToLab);

        _testOutputHelper.WriteLine(
            $"Unauthorised access denied. Requester: {answer.Requester.Id}, Author: {arnold.Id}");
    }

    [Fact]
    public void Unsuccessful_Lecture_Update_Non_Author()
    {
        var arnold = new User(new UserName("Arnold"));
        var bob = new User(new UserName("Bob"));

        LectureMaterials lecture1 = new(
            new ElementName("Lecture-1"),
            new Description("Train System"),
            new Description("Create Train System"),
            arnold);

        LectureResults result = lecture1.Update(bob, new Description("Create Route System"));

        var answer = result as LectureResults.UnAuthorizedAccessLecture;
        Assert.NotNull(answer);
        Assert.True(result is LectureResults.UnAuthorizedAccessLecture);

        _testOutputHelper.WriteLine(
            $"Unauthorised access denied. Requester: {answer.Requester.Id}, Author: {arnold.Id}");
    }

    [Fact]
    public void Unsuccessful_Subject_Update_Non_Author()
    {
        var arnold = new User(new UserName("Arnold"));
        var bob = new User(new UserName("Bob"));

        SubjectFactory examFactory = new ExamSubjectFactory();

        Subject physics = examFactory.CreateSubject(
            new ElementName("Physics"),
            new List<Laboratory>(),
            new List<LectureMaterials>(),
            new Grades(100),
            arnold);

        SubjectResults result = physics.UpdateSubject(bob, new ElementName("Chemistry"));

        var answer = result as SubjectResults.UnAuthorizedAccessSubject;
        Assert.NotNull(answer);
        Assert.True(result is SubjectResults.UnAuthorizedAccessSubject);

        _testOutputHelper.WriteLine(
            $"Unauthorised access denied. Requester: {answer.Requester.Id}, Author: {arnold.Id}");
    }

    [Fact]
    public void Check_Lab_Clone_isCorrect()
    {
        var arnold = new User(new UserName("Arnold"));
        var bob = new User(new UserName("Bob"));

        Laboratory lab1 = new(
            new ElementName("Lab-1"),
            new Description("Create Train System"),
            new Criteries("-20% after deadline"),
            new Grades(20),
            arnold);

        Laboratory lab2 = lab1.Clone(arnold);

        Laboratory lab3 = lab2.Clone(bob);

        LabResults result = lab3.BasedOn == lab1.Id
            ? new LabResults.LabOriginEqual()
            : new LabResults.LabOriginNotEqual();

        var answer = result as LabResults.LabOriginEqual;
        Assert.NotNull(answer);
        Assert.True(result is LabResults.LabOriginEqual);

        _testOutputHelper.WriteLine(
            $"Clone successful. Origin: {lab1.Id}, Clone: {lab3.BasedOn}");
    }

    [Fact]
    public void Check_Lecture_Clone_isCorrect()
    {
        var arnold = new User(new UserName("Arnold"));
        var bob = new User(new UserName("Bob"));

        LectureMaterials lecture1 = new(
            new ElementName("Lecture-1"),
            new Description("Train System"),
            new Description("Create Train System"),
            arnold);

        LectureMaterials lecture2 = lecture1.Clone(arnold);

        LectureMaterials lecture3 = lecture2.Clone(bob);

        LectureResults result = lecture3.BasedOn == lecture1.Id
            ? new LectureResults.LectureOriginEqual()
            : new LectureResults.LectureOriginNotEqual();

        var answer = result as LectureResults.LectureOriginEqual;
        Assert.NotNull(answer);
        Assert.True(result is LectureResults.LectureOriginEqual);

        _testOutputHelper.WriteLine(
            $"Clone successful. Origin: {lecture1.Id}, Clone: {lecture3.BasedOn}");
    }

    [Fact]
    public void Check_Subject_Clone_isCorrect()
    {
        var arnold = new User(new UserName("Arnold"));
        var bob = new User(new UserName("Bob"));

        var examFactory = new ExamSubjectFactory();

        Subject physics = examFactory.CreateSubject(
            new ElementName("Physics"),
            new List<Laboratory>(),
            new List<LectureMaterials>(),
            new Grades(100),
            arnold);

        Subject physicsClone1 = physics.Clone(arnold);
        Subject physicsClone2 = physicsClone1.Clone(bob);

        SubjectResults result = physicsClone2.BasedOn == physics.Id
            ? new SubjectResults.SubjectOriginEqual()
            : new SubjectResults.SubjectOriginNotEqual();

        var answer = result as SubjectResults.SubjectOriginEqual;
        Assert.NotNull(answer);
        Assert.True(result is SubjectResults.SubjectOriginEqual);

        _testOutputHelper.WriteLine(
            $"Clone successful. Origin: {physics.Id}, Clone: {physicsClone2.BasedOn}");
    }

    [Fact]
    public void False_Grades_Sum_ExamSubj()
    {
        var arnold = new User(new UserName("Arnold"));

        Laboratory lab1 = new(
            new ElementName("Lab-1"),
            new Description("Create Train System"),
            new Criteries("-20% after deadline"),
            new Grades(50),
            arnold);

        Laboratory lab2 = new(
            new ElementName("Lab-2"),
            new Description("Create Train System"),
            new Criteries("-20% after deadline"),
            new Grades(30),
            arnold);

        var examFactory = new ExamSubjectFactory();

        Subject physics = examFactory.CreateSubject(
            new ElementName("Physics"),
            [lab1, lab2],
            new List<LectureMaterials>(),
            new Grades(5),
            arnold);

        SubjectResults result = physics.SumGrades();

        var answer = result as SubjectResults.SubjectGradesSumIncorrect;
        Assert.NotNull(answer);
        Assert.True(result is SubjectResults.SubjectGradesSumIncorrect);

        _testOutputHelper.WriteLine(
            $"Sum of grades is incorrect. Sum: {answer.Sum}");
    }

    [Fact]
    public void False_Grades_Sum_PassFailSubj()
    {
        var arnold = new User(new UserName("Arnold"));

        Laboratory lab1 = new(
            new ElementName("Lab-1"),
            new Description("Create Train System"),
            new Criteries("-20% after deadline"),
            new Grades(50),
            arnold);

        Laboratory lab2 = new(
            new ElementName("Lab-2"),
            new Description("Create Train System"),
            new Criteries("-20% after deadline"),
            new Grades(52),
            arnold);

        var passFailFactory = new PassFailSubjectFactory();

        Subject physics = passFailFactory.CreateSubject(
            new ElementName("Physics"),
            [lab1, lab2],
            new List<LectureMaterials>(),
            new Grades(60),
            arnold);

        SubjectResults result = physics.SumGrades();

        var answer = result as SubjectResults.SubjectGradesSumIncorrect;
        Assert.NotNull(answer);
        Assert.True(result is SubjectResults.SubjectGradesSumIncorrect);

        _testOutputHelper.WriteLine(
            $"Sum of grades is incorrect. Sum: {answer.Sum}");
    }
}