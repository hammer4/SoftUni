using System;
using System.Collections.Generic;
using System.Linq;

public class JudgeLauncher
{
    public static void Main()
    {
        var judge = new Judge(); ;
        var idGen = new Random();

        Dictionary<int, Submission> submissions = new Dictionary<int, Submission>();
        List<int> ids = new List<int>();

        for (int i = 0; i < 500; i++)
        {
            int submissionId = idGen.Next(0, 100000);
            int userId = idGen.Next(0, 5);
            SubmissionType type = (SubmissionType)idGen.Next(0, 3);
            int contestId = idGen.Next(0, 5);
            int points = idGen.Next(0, 5);

            Submission submission = new Submission(submissionId, points, type, contestId, userId);

            if (!submissions.ContainsKey(submissionId))
            {
                submissions.Add(submissionId, submission);
                ids.Add(submissionId);
            }

            judge.AddContest(contestId);
            judge.AddUser(userId);
            judge.AddSubmission(submission);
        }

        int subId = idGen.Next(0, ids.Count);
        Submission sub = submissions[ids[subId]];

        IEnumerable<Submission> result = judge.SubmissionsInContestIdByUserIdWithPoints(sub.Points,
            sub.ContestId, sub.UserId);

        IEnumerable<Submission> expectedResult = submissions.Values.Where(x => x.ContestId == sub.ContestId
                                                    && x.UserId == sub.UserId &&
                                                    x.Points == sub.Points);

    }
}

