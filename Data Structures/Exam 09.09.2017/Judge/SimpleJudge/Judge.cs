using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Judge : IJudge
{
    HashSet<int> users = new HashSet<int>();
    HashSet<int> contests = new HashSet<int>();
    Dictionary<int, Submission> byInsertion = new Dictionary<int, Submission>();

    public void AddContest(int contestId)
    {
        if (!this.contests.Contains(contestId))
        {
            this.contests.Add(contestId);
        }
    }

    public void AddSubmission(Submission submission)
    {
        if (users.Contains(submission.UserId) && contests.Contains(submission.ContestId))
        {
            if (!byInsertion.ContainsKey(submission.Id))
            {
                this.byInsertion.Add(submission.Id, submission);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void AddUser(int userId)
    {
        if (!this.users.Contains(userId))
        {
            this.users.Add(userId);
        }
    }

    public void DeleteSubmission(int submissionId)
    {
        if (this.byInsertion.ContainsKey(submissionId))
        {
            this.byInsertion.Remove(submissionId);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return this.byInsertion.Values
            .OrderBy(s => s.Id);
    }

    public IEnumerable<int> GetUsers()
    {
        return this.users.OrderBy(c => c);
    }

    public IEnumerable<int> GetContests()
    {
        return this.contests.OrderBy(c => c);
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        return this.byInsertion.Values
            .Where(s => s.Type == submissionType && s.Points >= minPoints && s.Points <= maxPoints);
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        var query = byInsertion.Values
            .Where(s => s.UserId == userId)
            .OrderByDescending(s => s.Points)
            .ThenBy(s => s.Id)
            .Select(s => s.ContestId)
            .Distinct();

        return query;
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        var query =  this.byInsertion.Values
            .Where(s => s.UserId == userId && s.ContestId == contestId && s.Points == points);

        if (query.Any())
        {
            return query;
        }

        throw new InvalidOperationException();
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        return this.byInsertion.Values
            .Where(s => s.Type == submissionType)
            .Select(s => s.ContestId)
            .Distinct();

    }
}
