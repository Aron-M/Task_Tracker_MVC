[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Register(RegisterViewModel model)
{
    if (ModelState.IsValid)
    {
        // Use HttpClient to send a POST request to your API
        using (var client = new HttpClient())
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
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
    return View(model);
}