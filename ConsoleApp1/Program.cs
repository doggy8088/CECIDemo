using ConsoleApp1;
using var http = new HttpClient();
swaggerClient client = new swaggerClient(
    "https://localhost:7148/", 
    http);
await client.PostCourseAsync(new Course()
{
    CourseId = 0,
    Credits = 1,
    Title = "Title " + DateTime.Now,
});

var data = await client.GetCourseAllAsync();
foreach (var item in data)
{
    Console.WriteLine($"{item.CourseId}\t{item.Title}");
}