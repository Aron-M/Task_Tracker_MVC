// API UsersController
[HttpPost]
public async Task<IActionResult> Register([FromBody] User user)
{
    if (ModelState.IsValid)
    {
        // Hash the password before saving
        user.Password = HashPassword(user.Password);

        // Use HttpClient to send a POST request to your API
        using (var client = new HttpClient())
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5000/api/users", content);

            if (response.IsSuccessStatusCode)
            {
                // Handle success (e.g., redirect to dashboard)
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                // Handle errors (e.g., display error message)
                ModelState.AddModelError(string.Empty, "Registration failed.");
            }
        }
    }
    return BadRequest(ModelState);
}