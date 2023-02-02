namespace KostaTestTask.Attributes
{
    public class FieldNameAttribute : Attribute
    {
        public string FieldName { get; set; }
        public FieldNameAttribute(string fieldName)
        {
            this.FieldName = fieldName;
        }
    }
}
