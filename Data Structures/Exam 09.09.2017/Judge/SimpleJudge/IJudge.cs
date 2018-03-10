using System.Collections.Generic;

public interface IJudge
{
    void AddContest(int contestId);
    void AddSubmission(Submission submission);
    void AddUser(int userId);

    void DeleteSubmission(int submissionId);

    IEnumerable<Submission> GetSubmissions();
    IEnumerable<int> GetUsers();
    IEnumerable<int> GetContests();

    IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType);
    IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId);
    IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId);
    IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType);
}
