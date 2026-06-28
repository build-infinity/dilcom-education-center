namespace DilcomEducationCenter.Domain.Common;

public static class RoleAssignmentPolicy
{
    private static readonly Dictionary<string, HashSet<string>> _assignable = new()
    {
        ["SuperAdmin"]   = new () { "Admin", "Teacher", "Receptionist", },
        ["Admin"]        = new () { "Teacher", "Receptionist", },
        ["Teacher"]      = new (),
        ["Receptionist"] = new ()
    };

    public static bool CanAssign(string assignerRole, string roleToAssign) =>
          _assignable.TryGetValue(assignerRole, out var allowed) && allowed.Contains(roleToAssign);         
}