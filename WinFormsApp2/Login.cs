namespace WinFormsApp2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            string un = username.Text.Trim();
            string pass = password.Text.Trim();
            if (!string.IsNullOrEmpty(un) && !string.IsNullOrEmpty(pass))
            {


                if (username.Text.Trim() != "sta001" & password.Text.Trim() != "givemethekeys123")
                {
                    MessageBox.Show(" Username  and Password is wrong.Please try again !!!");
                }
                else if (username.Text.Trim() != "sta001")
                {
                    MessageBox.Show("Username is incorrect.Please try again !!!");
                }
                else if (password.Text.Trim() != "givemethekeys123")
                {
                    MessageBox.Show("Password is Wrong.Please try again!!!");
                }
                else
                {
                    output.Text = "Login Sucessfull.....";
                    new Dashboard().Show();
                }
            }
            else
            {
                MessageBox.Show("Please enter credentials");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

