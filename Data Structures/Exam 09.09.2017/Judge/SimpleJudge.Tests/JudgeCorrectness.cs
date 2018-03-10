using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class JudgeCorrectness
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
    public void AddUser_SingleUser_ShouldAddUser()
    {
        Assert.AreEqual(0, this.judge.GetUsers().Count());

        int id = this.idGen.Next(0, 100000);
        this.judge.AddUser(id);

        int result = this.judge.GetUsers().First();
        Assert.AreEqual(id, result);
        Assert.AreEqual(1, this.judge.GetUsers().Count());
    }

    [Test]
    public void GetUsers_MultipleUsers_ShouldReturnOrderedCollection()
    {
        // Arrange
        List<int> users = new List<int>()
            {
                this.idGen.Next(0, 100000),
                this.idGen.Next(0, 100000),
                this.idGen.Next(0, 100000),
                this.idGen.Next(0, 100000)
            };

        // Act
        foreach (int user in users)
        {
            this.judge.AddUser(user);
        }

        IEnumerable<int> result = this.judge.GetUsers();

        CollectionAssert.AreEqual(users.OrderBy(u => u), result);
        Assert.AreEqual(users.Count, result.Count());
    }

    [Test]
    public void AddContest_SingleContest_ShouldAddContest()
    {
        Assert.AreEqual(0, this.judge.GetContests().Count());

        int id = this.idGen.Next(0, 100000);
        this.judge.AddContest(id);

        int result = this.judge.GetContests().First();

        Assert.AreEqual(id, result);
        Assert.AreEqual(1, this.judge.GetContests().Count());
    }

    [Test]
    public void AddContest_MultipleContests_ShouldIncreaseCount()
    {
        List<int> contests = new List<int>()
            {
                this.idGen.Next(0, 100000),
                this.idGen.Next(0, 100000),
                this.idGen.Next(0, 100000),
                this.idGen.Next(0, 100000)
            };

        foreach (int contest in contests)
        {
            this.judge.AddContest(contest);
        }

        IEnumerable<int> result = this.judge.GetContests();

        Assert.AreEqual(contests.Count, result.Count());
        CollectionAssert.AreEqual(contests.OrderBy(contest => contest), result);
    }

    [Test]
    public void GetSubmissions_MultipleSubmissions_ShouldReturnOrderedCollection()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();

        for (int i = 0; i < 5; i++)
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

        IEnumerable<Submission> result = this.judge.GetSubmissions();

        CollectionAssert.AreEqual(submissions.Values.OrderBy(x => x.Id), result);
    }

    [Test]
    public void AddSubmission_SingleSubmissionWithValidContestAndUser_ShouldIncreaseCount()
    {
        Assert.AreEqual(0, this.judge.GetSubmissions().Count());

        int submissionId = this.idGen.Next(0, 100000);
        int userId = this.idGen.Next(0, 100000);
        int contestId = this.idGen.Next(0, 100000);
        int points = this.idGen.Next(0, 100000);
        SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);

        Submission submission = new Submission(submissionId, points, type, contestId, userId);

        this.judge.AddContest(contestId);
        this.judge.AddUser(userId);
        this.judge.AddSubmission(submission);

        IEnumerable<Submission> result = this.judge.GetSubmissions();

        Assert.AreEqual(submissionId, result.First().Id);
        Assert.AreEqual(type, result.First().Type);
        Assert.AreEqual(points, result.First().Points);
        Assert.AreEqual(contestId, result.First().ContestId);
        Assert.AreEqual(userId, result.First().UserId);

        Assert.AreEqual(1, this.judge.GetSubmissions().Count());
    }

    [Test]
    public void AddSubmission_SingleSubmissionInvalidUserId_ShouldThrow()
    {
        int submissionId = this.idGen.Next(0, 100000);
        int userId = this.idGen.Next(0, 100000);
        int contestId = this.idGen.Next(0, 100000);
        int points = this.idGen.Next(0, 100000);
        SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);

        Submission submission = new Submission(submissionId, points, type, contestId, userId);

        this.judge.AddContest(contestId);

        Assert.Throws<InvalidOperationException>(() => this.judge.AddSubmission(submission));
    }

    [Test]
    public void AddSubmission_SingleSubmissionInvalidContestId_ShouldThrow()
    {
        int submissionId = this.idGen.Next(0, 100000);
        int userId = this.idGen.Next(0, 100000);
        int contestId = this.idGen.Next(0, 100000);
        int points = this.idGen.Next(0, 100000);
        SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);

        Submission submission = new Submission(submissionId, points, type, contestId, userId);

        this.judge.AddUser(userId);

        Assert.Throws<InvalidOperationException>(() => this.judge.AddSubmission(submission));
    }

    [Test]
    public void DeleteSubmission_ExistingSubmission_ShouldDeleteCorrectSubmission()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();
        List<int> ids = new List<int>();

        for (int i = 0; i < 5; i++)
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
                ids.Add(submissionId);
            }

            this.judge.AddContest(contestId);
            this.judge.AddUser(userId);
            this.judge.AddSubmission(submission);
        }
        int subId = this.idGen.Next(0, ids.Count);
        Submission sub = submissions[ids[subId]];

        this.judge.DeleteSubmission(sub.Id);
        submissions.Remove(sub.Id);

        IEnumerable<Submission> result = this.judge.GetSubmissions();

        Assert.AreEqual(submissions.Count, result.Count());
        CollectionAssert.AreEqual(submissions.Values.OrderBy(x => x), result);
    }

    [Test]
    public void DeleteSubmission_NonExistingSubmission_ShouldThrow()
    {
        int submissionId = this.idGen.Next(0, 100000);

        Assert.Throws<InvalidOperationException>(() => this.judge.DeleteSubmission(submissionId));
    }

    [Test]
    public void ContestsBySubmissionType_WithSingleSubmission_ShouldReturnSingleContest()
    {
        int submissionId = this.idGen.Next(0, 100000);
        int userId = this.idGen.Next(0, 100000);
        int contestId = this.idGen.Next(0, 100000);
        int points = this.idGen.Next(0, 100000);
        SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);

        Submission submission = new Submission(submissionId, points, type, contestId, userId);

        this.judge.AddContest(contestId);
        this.judge.AddUser(userId);
        this.judge.AddSubmission(submission);

        int result = this.judge.ContestsBySubmissionType(submission.Type).Single();

        Assert.AreEqual(contestId, result);
    }

    [Test]
    public void ContestsBySubmissionType_WithNonExistingType_ShouldReturnEmptyCollection()
    {
        int submissionId = this.idGen.Next(0, 100000);
        int userId = this.idGen.Next(0, 100000);
        int contestId = this.idGen.Next(0, 100000);
        int points = this.idGen.Next(0, 100000);
        SubmissionType type = (SubmissionType)this.idGen.Next(1, 3);

        Submission submission = new Submission(submissionId, points, type, contestId, userId);

        this.judge.AddContest(contestId);
        this.judge.AddUser(userId);
        this.judge.AddSubmission(submission);

        IEnumerable<int> result = this.judge.ContestsBySubmissionType(submission.Type - 1);

        Assert.AreEqual(0, result.Count());
    }

    [Test]
    public void ContestsBySubmissionType_MultipleSubmissionsWithSingleType_ShouldReturnCorrectContests()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();

        SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);

        for (int i = 0; i < 10; i++)
        {
            int submissionId = this.idGen.Next(0, 100000);
            int userId = this.idGen.Next(0, 100000);
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

        IEnumerable<int> result = this.judge.ContestsBySubmissionType(type);

        CollectionAssert.AreEquivalent(submissions.Values.Select(x => x.ContestId), result);
    }

    [Test]
    public void ContestsBySubmissionType_MultipleSubmissionsWithDifferentTypes_ShouldReturnPartialContests()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();

        for (int i = 0; i < 10; i++)
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

        IEnumerable<int> result = this.judge.ContestsBySubmissionType(SubmissionType.CSharpCode);

        CollectionAssert.AreEqual(submissions.Values.Where(x => x.Type == SubmissionType.CSharpCode).Select(x => x.ContestId), result);
    }

    [Test]
    public void SubmissionsInContestIdByUserIdWithPoints_WithValidData_ShouldReturnValidResult()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();
        List<int> ids = new List<int>();

        for (int i = 0; i < 500; i++)
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

        IEnumerable<Submission> result = this.judge.SubmissionsInContestIdByUserIdWithPoints(sub.Points,
            sub.ContestId, sub.UserId);

        IEnumerable<Submission> expectedResult = submissions.Values.Where(x => x.ContestId == sub.ContestId
                                                    && x.UserId == sub.UserId &&
                                                    x.Points == sub.Points);

        CollectionAssert.AreEquivalent(expectedResult, result);
    }

    [Test]
    public void SubmissionsInContestIdByUserIdWithPoints_WithInvalidPoints_ShouldThrow()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();
        List<int> ids = new List<int>();

        for (int i = 0; i < 500; i++)
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

        Assert.Throws<InvalidOperationException>(() => this.judge.SubmissionsInContestIdByUserIdWithPoints(15,
            sub.ContestId, sub.UserId));
    }

    [Test]
    public void SubmissionsInContestIdByUserIdWithPoints_WithInvalidContest_ShouldThrow()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();
        List<int> ids = new List<int>();

        for (int i = 0; i < 5; i++)
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

        Assert.Throws<InvalidOperationException>(() => this.judge.SubmissionsInContestIdByUserIdWithPoints(sub.Points,
            6, sub.UserId));
    }

    [Test]
    public void SubmissionsInContestIdByUserIdWithPoints_WithInvalidUser_ShouldThrow()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();
        List<int> ids = new List<int>();

        for (int i = 0; i < 5; i++)
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

        Assert.Throws<InvalidOperationException>(() => this.judge.SubmissionsInContestIdByUserIdWithPoints(sub.Points,
            sub.ContestId, 7));
    }

    [Test]
    public void SubmissionsInRange_WithValidData_ShouldReturnCorrectSubmissions()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();

        for (int i = 0; i < 500; i++)
        {
            int submissionId = this.idGen.Next(0, 100000);
            int userId = this.idGen.Next(0, 50);
            SubmissionType type = (SubmissionType)this.idGen.Next(0, 3);
            int contestId = this.idGen.Next(0, 5);
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

        int minPoints = this.idGen.Next(0, 15);
        int maxPoints = this.idGen.Next(15, 30);
        SubmissionType expectedType = (SubmissionType)this.idGen.Next(0, 3);

        List<Submission> result =
            this.judge.SubmissionsWithPointsInRangeBySubmissionType(minPoints, maxPoints, expectedType).ToList();

        IEnumerable<Submission> expected =
            submissions.Values.Where(x => x.Points >= minPoints && x.Points <= maxPoints && x.Type == expectedType);

        CollectionAssert.AreEquivalent(expected, result);
    }

    [Test]
    public void ContestsByPoints_WithExistingSubmissions_ShouldReturnCorrectContests()
    {
        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();

        for (int i = 0; i < 500; i++)
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

        IEnumerable<int> result = this.judge.ContestsByUserIdOrderedByPointsDescThenBySubmissionId(3);

        CollectionAssert.AreEqual(expected, result);
    }
}
