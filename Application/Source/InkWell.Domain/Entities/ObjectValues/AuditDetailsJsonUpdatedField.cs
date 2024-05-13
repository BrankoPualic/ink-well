namespace InkWell.Domain.Entities.ObjectValues;

public class AuditDetailsJsonUpdatedField
{
    public AuditDetailsJsonUpdatedField(string column, string oldValue, string newValue)
    {
        Column = column;
        Old = oldValue;
        New = newValue;
    }

    public string Column { get; set; } = string.Empty;
    public string Old { get; set; } = string.Empty;
    public string New { get; set; } = string.Empty;
}