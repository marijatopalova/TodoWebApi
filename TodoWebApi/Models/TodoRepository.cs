namespace TodoWebApi.Models
{
    public class TodoRepository : ITodoRepository
    {
        private static List<TodoItem> _todos = new();

        public TodoRepository()
        {
            _todos.Add(new TodoItem { Key = "1", Name = "Walk Dog", IsComplete = false });
            _todos.Add(new TodoItem { Key = "2", Name = "Do Homework", IsComplete = true });
            _todos.Add(new TodoItem { Key = "3", Name = "Do the dishes", IsComplete = false });
        }

        public void Add(TodoItem item)
        {
            item.Key = (_todos.Count + 1).ToString();
            _todos.Add(item);
        }

        public TodoItem Find(string key)
        {
            var item = _todos.Where(x => x.Key == key).FirstOrDefault();
            return item;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos;
        }

        public TodoItem Remove(string key)
        {
            var item = Find(key);
            _todos.Remove(item);
            return item;
        }

        public void Update(TodoItem item)
        {
            //TODO
        }
    }
}
