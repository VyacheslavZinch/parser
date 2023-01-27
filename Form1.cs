using MainRequest;

namespace parser;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e) //start
    {
        string text = textBox1.Text.ToString();
        CollectDataFromSearch collect = new CollectDataFromSearch(text);
        collect.ParsedLink(collect._html);

    }

    private void button1_Click(object sender, EventArgs e) //info
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
              
    }
}
