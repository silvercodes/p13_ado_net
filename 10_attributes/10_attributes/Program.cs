


[AttributeUsage(AttributeTargets.Class)]
class EmailLengthAttribute: Attribute
{
    public int Len { get; }
    public EmailLengthAttribute(int len)
    {
        Len = len;
    }
}


[EmailLength(10)]
class User
{
    public string Email { get; set; }
    public User(string email)
    {
        Email = email;
    }
    
    public bool ValidateEmail()
    {
        Type t = typeof(User);
        object[] attributes = t.GetCustomAttributes(false);

        foreach(object o in attributes)
        {
            if (o is EmailLengthAttribute ela)
            {
                if (Email.Length < ela.Len)
                    return false;
            }
        }

        return true;
    }
}
