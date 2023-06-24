namespace RiskManagementAppSharedUI.Beans;

public class RiskBean
{
    private int _riskId;
    public int GetRiskId()
    {
        return _riskId;
    }

    public void SetRiskId(int riskId)
    {
        _riskId = riskId;
    }

    public string[] riskImpact = { "niet merkbaar", "klein", "gemiddeld", "groot", "deastrues" };

    public string[] riskProbability = { "> jaarlijks", "jaarlijks", "maandelijks", "wekelijks", "dagelijks" };
}
