using ConsoleApp1;
using var http = new HttpClient();
swaggerClient client = new swaggerClient(
    "https://localhost:7148/", 
    http);

// 新增的 Course 資料
var c = await client.PostCourseAsync(new Course()
{
    CourseId = 0,
    Credits = 1,
    Title = "Title " + DateTime.Now,
});

// 取回所有課程資料
var data = await client.GetCourseAllAsync();
foreach (var item in data)
{
    Console.WriteLine($"{item.CourseId}\t{item.Title}");
}

// 刪除剛剛新增的 Course 資料
//await client.DeleteCourseByIdAsync(c.CourseId);