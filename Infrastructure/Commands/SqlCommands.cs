namespace Infrastructure.Commands;

public class SqlCommands
{
    public const string ConnectionString =
        "Server=localhost;Port=5432;Database=tasks_db;User Id=postgres;Password=01062007;";

    public const string GetAllCategories = "SELECT * FROM categories";
    public const string GetCategoryById = "SELECT * FROM categories WHERE id = @id";
    public const string AddCategory = "INSERT INTO categories (name,createdat) VALUES (@name,@createdat)";
    public const string UpdateCategory = "UPDATE categories SET name = @name, createdat = @createdat WHERE id = @id";
    public const string DeleteCategory = "DELETE FROM categories WHERE id = @id";
    
    public const string GetAllComments = "SELECT * FROM comments";
    public const string GetCommentById = "SELECT * FROM comments WHERE id = @id";
    public const string AddComment = "INSERT INTO comments (taskid,createdat, content, userid) VALUES (@taskid,@createdat, @content, @userid)";
    public const string UpdateComment = "UPDATE comments SET taskid = @taskid, createdat = @createdat, userid = @userid, content = @content WHERE id = @id";
    public const string DeleteComment = "DELETE FROM comments WHERE id = @id";
    
    public const string GetAllTasks = "SELECT * FROM tasks";
    public const string GetTaskById = "SELECT * FROM tasks WHERE id = @id";
    public const string AddTask = "INSERT INTO tasks (title,createdat, description, userid, iscompleted, duedate, categoryid, priority)"
                                            +"VALUES (@title,@createdat, @description, @userid, @iscompleted, @duedate, @categoryid, @priority)";
    public const string UpdateTask = "UPDATE tasks SET title = @title, createdat = @createdat, userid = @userid, description = @description, iscompleted = @iscompleted, duedate = @duedate, categoryid = @categoryid, priority = @priority WHERE id = @id";
    public const string DeleteTask = "DELETE FROM tasks WHERE id = @id";
    
    public const string GetAllTaskAttachments = "SELECT * FROM taskattachments";
    public const string GetTaskAttachmentById = "SELECT * FROM taskattachments WHERE id = @id";
    public const string AddTaskAttachment = "INSERT INTO taskattachments (taskid,createdat, filepath) VALUES (@taskid,@createdat, @filepath)";
    public const string UpdateTaskAttachment = "UPDATE taskattachments SET taskid = @taskid, createdat = @createdat, filepath = @filepath WHERE id = @id";
    public const string DeleteTaskAttachment = "DELETE FROM taskattachments WHERE id = @id";
    
    public const string GetAllTaskHistories = "SELECT * FROM taskhistoires";
    public const string GetTaskHistoryById = "SELECT * FROM taskhistoires WHERE id = @id";
    public const string AddTaskHistory = "INSERT INTO taskhistoires (taskid,createdat, changedescription) VALUES (@taskid,@createdat, @changedescription)";
    public const string UpdateTaskHistory = "UPDATE taskhistoires SET taskid = @taskid, createdat = @createdat, changedescription = @changedescription WHERE id = @id";
    public const string DeleteTaskHistory = "DELETE FROM taskhistoires WHERE id = @id";
    
    public const string GetAllUsers = "SELECT * FROM users";
    public const string GetUserById = "SELECT * FROM users WHERE id = @id";
    public const string AddUser = "INSERT INTO users (username,passwordhash, email, createdat ) VALUES (@username, @passwordhash, @email,@createdat)";
    public const string UpdateUser = "UPDATE users SET username = @username, createdat = @createdat, passwordhash = @passwordhash, email = @email WHERE id = @id";
    public const string DeleteUser = "DELETE FROM users WHERE id = @id";
    
    public const string GetAllTasksByUserId = @"select * from tasks WHERE userid = @userid";
    public const string GetTasksWithUserAndCategory = @"
        SELECT 
            t.Id, 
            t.Title, 
            t.Description, 
            t.IsCompleted, 
            t.DueDate,
            t.UserId, 
            t.CategoryId, 
            t.Priority, 
            t.CreatedAt,
            u.Username, 
            u.Email, 
            u.PasswordHash, 
            u.CreatedAt AS UserCreatedAt,
            c.Name AS CategoryName, 
            c.CreatedAt AS CategoryCreatedAt
        FROM Tasks t
        JOIN Users u ON t.UserId = u.Id
        JOIN Categories c ON t.CategoryId = c.Id";
    public const string GetCountTasks = @"select count(*) from tasks where categoryid = @categoryid";
    public const string GetTaskByOrder = "select * from tasks order by duedate";
    public const string GetHistoriesOfTasks = @"select * from taskhistoires where taskid = @taskid";
}   