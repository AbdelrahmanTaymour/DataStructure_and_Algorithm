namespace DSA_ProblemSolving.Dictionary___Hashset;

public class Skills_Matcher
{
    public IEnumerable<string> SkillMatcher(HashSet<string> candidateSkills, HashSet<string> jobRequirements)
    {
        candidateSkills.IntersectWith(jobRequirements);
        return candidateSkills;
    }
}