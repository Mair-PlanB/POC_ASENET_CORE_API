namespace FrontendNeu
{
    using Shared.Models;
    using Shared;
    using Newtonsoft.Json;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PostTodoItem().Wait();
            RefreshItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DeleteItem(this.listView1.SelectedItems[0].Text).Result);
            RefreshItems();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PutItem().Wait();
            RefreshItems();
        }

        private void RefreshItems()
        {
            this.listView1.Items.Clear();
            var todoItems = GetTodoItems();

            if (todoItems == null)
                return;

            foreach (var todoItem in todoItems)
            {
                var item = new ListViewItem(todoItem.Id.ToString());
                item.SubItems.Add(todoItem.Name);
                item.SubItems.Add(todoItem.IsComplete.ToString());
                item.Checked = todoItem.IsComplete;
                this.listView1.Items.Add(item);
            }
        }

        private async Task<string> PostTodoItem()
        {
            var todoItem = new TodoItem();
            todoItem.Name = this.NameTextBox.Text;
            todoItem.IsComplete = false;

            var serializedData = JsonConvert.SerializeObject(todoItem);
            return await HttpHelper.HttpPostRequest(ApiConst.ApiItemRoute, serializedData);
        }

        private List<TodoItem> GetTodoItems()
        {
            var serializedData = HttpHelper.HttpGetRequest(ApiConst.ApiItemRoute);
            return JsonConvert.DeserializeObject<List<TodoItem>>(serializedData) ?? new List<TodoItem>();
        }

        private async Task<string> DeleteItem(string itemName)
        {
            return await HttpHelper.HttpRequest(HttpHelper.HttpType.DELETE, ApiConst.ApiItemRoute, itemName);
        }

        private async Task<string> PutItem()
        {
            var data = new TodoItem()
            {
                Id = int.Parse(this.IdTextBox.Text),
                Name = this.NameTextBox.Text,
                IsComplete = this.checkBox1.Checked
            };

            var serializedData = JsonConvert.SerializeObject(data);
            return await HttpHelper.HttpPutRequest(ApiConst.ApiItemRoute, this.IdTextBox.Text, serializedData);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                this.NameTextBox.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                this.IdTextBox.Text = this.listView1.SelectedItems[0].SubItems[0].Text;
                this.checkBox1.Checked = (this.listView1.SelectedItems[0].SubItems[2].Text == "True") ? true : false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.ShowDialog();
        }
    }
}