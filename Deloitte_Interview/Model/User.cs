public class UserA
{
    public string Login { get; set; }
    public string Name { get; set; }
    public DateTime? LastLogin { get; set; }

    public override bool Equals(object? input)
    {
        UserB? other = input as UserB;

        if (other == null)
            return false;

        if (this.Login != other.LoginID)
            return false;

        if (this.Name.ToLower() != other.FullName.ToLower())
            return false;

        if (this.LastLogin.HasValue && other.LoginDate.HasValue)
        {
            if (this?.LastLogin.Value.ToString("yyyy-mm-dd") != other?.LoginDate.Value.ToString("yyyy-mm-dd"))
                return false;
        }

        return true;
    }
}

public class UserB
{
    public string LoginID { get; set; }
    public string FullName { get; set; }
    public DateTime? LoginDate { get; set; }

    public override bool Equals(object? input)
    {
        UserA? other = input as UserA;

        if (other == null) 
            return false;

        if (this.LoginID != other.Login)
            return false;

        if (this.FullName.ToLower() != other.Name.ToLower())
            return false;

        if (this.LoginDate.HasValue && other.LastLogin.HasValue)
        {
            if (this?.LoginDate.Value.ToString("yyyy-mm-dd") != other?.LastLogin.Value.ToString("yyyy-mm-dd"))
                return false;
        }

        return true;
    }
}