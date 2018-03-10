using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class JudgePerformance
{
    private IJudge judge;
    private Random idGen;

    [SetUp]
    public void TestSetUp()
    {
        this.judge = new Judge();
        this.idGen = new Random();
    }

    [Test]
    [Timeout(500)]
    public void GetUsers_MultipleUsers_ShouldReturnOrderedCollection()
    {
        HashSet<int> users = new HashSet<int>();

        for (int i = 0; i < 50000; i++)
        {
            users.Add(this.idGen.Next(0, 100000));
        }

        var sw = Stopwatch.StartNew();

        foreach (int user in users)
        {
            this.judge.AddUser(user);
        }

        List<int> result = this.judge.GetUsers().ToList();

        sw.Stop();

        Assert.Less(sw.ElapsedMilliseconds, 250);
        CollectionAssert.AreEqual(users.OrderBy(u => u), result);


        Assert.AreEqual(users.Count, result.Count);
    }

    [Test]
    [Timeout(700)]
    public void AddContest_MultipleContests_ShouldIncreaseCount()
    {
        HashSet<int> contests = new HashSet<int>();

        for (int i = 0; i < 50000; i++)
        {
            contests.Add(this.idGen.Next(0, 100000));
        }

        var sw = Stopwatch.StartNew();

        foreach (int user in contests)
        {
            this.judge.AddContest(user);
        }

        List<int> result = this.judge.GetContests().ToList();

        sw.Stop();

        Assert.Less(sw.ElapsedMilliseconds, 300);
        Assert.AreEqual(contests.Count, result.Count);
        CollectionAssert.AreEqual(contests.OrderBy(contest => contest), result);
    }

    [Test]
    [Timeout(1000)]
    public void GetSubmissions_MultipleSubmissions_ShouldReturnOrderedCollection()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();

        var sw = Stopwatch.StartNew();
        for (int i = 0; i < 30000; i++)
        {
            int submissionId = this.idGen.Next(0, 100000);
            int userId = this.idGen.Next(0, 100000);
            int contestId = this.idGen.Next(0, 100000);
            int points = this.idGen.Next(0, 100000);
            SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);

            Submission submission = new Submission(submissionId, points, type, contestId, userId);

            if (!submissions.ContainsKey(submissionId))
            {
                submissions.Add(submissionId, submission);
            }

            this.judge.AddContest(contestId);
            this.judge.AddUser(userId);
            this.judge.AddSubmission(submission);
        }

        List<Submission> result = this.judge.GetSubmissions().ToList();
        sw.Stop();

        Assert.Less(sw.ElapsedMilliseconds, 550);

        CollectionAssert.AreEqual(submissions.Values.OrderBy(x => x.Id), result);
    }

    [Test]
    [Timeout(3000)]
    public void ContestsBySubmissionType_MultipleSubmissionsWithSingleType_ShouldReturnCorrectContests()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();

        for (int i = 0; i < 80000; i++)
        {
            int submissionId = this.idGen.Next(0, 100000);
            int userId = this.idGen.Next(0, 100000);
            SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);
            int contestId = this.idGen.Next(0, 100000);
            int points = this.idGen.Next(0, 100000);

            Submission submission = new Submission(submissionId, points, type, contestId, userId);

            if (!submissions.ContainsKey(submissionId))
            {
                submissions.Add(submissionId, submission);
            }

            this.judge.AddContest(contestId);
            this.judge.AddUser(userId);
            this.judge.AddSubmission(submission);
        }

        var sw = Stopwatch.StartNew();

        List<int> result = this.judge.ContestsBySubmissionType(SubmissionType.JavaScriptCode).ToList();
        sw.Stop();

        var expected = submissions.Values.Where(x => x.Type == SubmissionType.JavaScriptCode)
            .Select(x => x.ContestId).Distinct().ToList();

        Assert.Less(sw.ElapsedMilliseconds, 10);

        CollectionAssert.AreEquivalent(expected, result);
    }

    [Test]
    [Timeout(1200)]
    public void SubmissionsInContestIdByUserIdWithPoints_WithValidData_ShouldReturnValidResult()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();
        List<int> ids = new List<int>();

        for (int i = 0; i < 50000; i++)
        {
            int submissionId = this.idGen.Next(0, 100000);
            int userId = this.idGen.Next(0, 5);
            SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);
            int contestId = this.idGen.Next(0, 5);
            int points = this.idGen.Next(0, 5);

            Submission submission = new Submission(submissionId, points, type, contestId, userId);

            if (!submissions.ContainsKey(submissionId))
            {
                submissions.Add(submissionId, submission);
                ids.Add(submissionId);
            }

            this.judge.AddContest(contestId);
            this.judge.AddUser(userId);
            this.judge.AddSubmission(submission);
        }

        int subId = this.idGen.Next(0, ids.Count);
        Submission sub = submissions[ids[subId]];

        var sw = Stopwatch.StartNew();
        List<Submission> result = this.judge.SubmissionsInContestIdByUserIdWithPoints(sub.Points,
            sub.ContestId, sub.UserId).ToList();

        sw.Stop();
        IEnumerable<Submission> expectedResult = submissions.Values.Where(x => x.ContestId == sub.ContestId
                                                                               && x.UserId == sub.UserId &&
                                                                               x.Points == sub.Points);

        Assert.Less(sw.ElapsedMilliseconds, 250);
        CollectionAssert.AreEquivalent(expectedResult, result);
    }

    [Test]
    [Timeout(7000)]
    public void SubmissionsInRange_WithValidData_ShouldReturnCorrectSubmissions()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();

        for (int i = 0; i < 20000; i++)
        {
            int submissionId = this.idGen.Next(0, 100000);
            int userId = this.idGen.Next(0, 150);
            SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);
            int contestId = this.idGen.Next(0, 30);
            int points = this.idGen.Next(0, 100);

            Submission submission = new Submission(submissionId, points, type, contestId, userId);

            if (!submissions.ContainsKey(submissionId))
            {
                submissions.Add(submissionId, submission);
            }

            this.judge.AddContest(contestId);
            this.judge.AddUser(userId);
            this.judge.AddSubmission(submission);
        }

        int minPoints = this.idGen.Next(0, 50);
        int maxPoints = this.idGen.Next(50, 100);
        SubmissionType expectedType = (SubmissionType)this.idGen.Next(0, 3);

        var sw = Stopwatch.StartNew();
        List<Submission> result =
            this.judge.SubmissionsWithPointsInRangeBySubmissionType(minPoints, maxPoints, expectedType).ToList();

        sw.Stop();

        IEnumerable<Submission> expected =
            submissions.Values.Where(x => x.Points >= minPoints && x.Points <= maxPoints && x.Type == expectedType);

        Assert.Less(sw.ElapsedMilliseconds, 100);
        CollectionAssert.AreEquivalent(expected, result);
    }

    [Test]
    [Timeout(1000)]
    public void ContestsByPoints_WithExistingSubmissions_ShouldReturnCorrectContests()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();

        for (int i = 0; i < 30000; i++)
        {
            int submissionId = this.idGen.Next(0, 100000);
            int userId = this.idGen.Next(0, 5);
            SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);
            int contestId = this.idGen.Next(0, 15);
            int points = this.idGen.Next(0, 30);

            Submission submission = new Submission(submissionId, points, type, contestId, userId);

            if (!submissions.ContainsKey(submissionId))
            {
                submissions.Add(submissionId, submission);
            }


            this.judge.AddContest(contestId);
            this.judge.AddUser(userId);
            this.judge.AddSubmission(submission);
        }

        var expected = submissions.Values.Where(x => x.UserId == 3).GroupBy(x => x.ContestId).Select(x => x.OrderByDescending(s => s.Points).ThenBy(s => s.Id).First()).OrderByDescending(x => x.Points).ThenBy(x => x.Id).Select(x => x.ContestId);
        var sw = Stopwatch.StartNew();
        IEnumerable<int> result = this.judge.ContestsByUserIdOrderedByPointsDescThenBySubmissionId(3);
        sw.Stop();

        Assert.Less(sw.ElapsedMilliseconds, 200);
        CollectionAssert.AreEqual(expected, result);
    }
}
