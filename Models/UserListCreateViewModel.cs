using System.Collections.Generic;
using TaskTrackerMVC.Models;

public class UserListCreateViewModel
{
    public IEnumerable<UserModel> Users { get; set; } = new List<UserModel>();
    public UserModel NewUser { get; set; } = new UserModel();
}