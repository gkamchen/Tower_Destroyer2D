using GameClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public partial class Match : Form
    {

        private delegate void SetVisibleDelegate(bool visible);
        private delegate void InitializeMatrixDelegate(int[] itens);
        private enum Type
        {
            Terra = 1,
            Pedra = 2,
            Item = 3,
            Unidade1 = 4,
            Unidade2 = 5,
            Unidade3 = 6
        }

        public Match()
        {
            InitializeComponent();
        }

        private int[] InitializeArrayWithNoDuplicates(int size)
        {
            Random rand = new Random();

            return Enumerable.Repeat<int>(0, size).Select((value, index) => new { i = index, rand = rand.Next() }).OrderBy(x => x.rand).Select(x => x.i).ToArray();
        }

        public void InitializeMatrix(int[] itens)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new InitializeMatrixDelegate(InitializeMatrix), new object[]
                {
                    itens
                });
            }
            else
            {
                int btnWidth = 50;
                int btnHeight = 50;
                int btnX = 0;
                int btnY = 0;
                int indice = 0;
                Button btn;

                int totalLines = 14;
                int totalColumns = 25;
                int totalLinesSeparator = totalLines / 2;

                for (int i = 0; i < totalLinesSeparator; i++)
                {
                    for (int j = 0; j < totalColumns; j++)
                    {
                        btn = new Button();
                        btn.Location = new Point(btnX, btnY);
                        btn.Width = btnWidth;
                        btn.Height = btnHeight;
                        btn.BackColor = Color.Black;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

                        switch (itens[indice])
                        {
                            case (Int32)Type.Terra:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Terra, btn.BackgroundImage = Resources.Grass);
                                    Btn_Click(sender, e, Type.Terra, Color.Green, "T");
                                };
                                break;
                            case (Int32)Type.Pedra:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Pedra, btn.BackgroundImage = Resources.Pedra);
                                    Btn_Click(sender, e, Type.Pedra, Color.Gray, "P");
                                };
                                break;
                            case (Int32)Type.Unidade1:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Unidade1, btn.BackgroundImage = Resources.Unity1__Up_);
                                    Btn_Click(sender, e, Type.Unidade1, Color.Blue, "U1");
                                };
                                break;
                            case (Int32)Type.Unidade2:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Unidade2, btn.BackgroundImage = Resources.Unity2__Up_);
                                    Btn_Click(sender, e, Type.Unidade2, Color.DarkOrange, "U2");
                                };
                                break;
                            case (Int32)Type.Unidade3:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Unidade3, btn.BackgroundImage = Resources.Unity3__Up__png);
                                    Btn_Click(sender, e, Type.Unidade3, Color.Red, "U3");
                                };
                                break;
                            case (Int32)Type.Item:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Item, btn.BackgroundImage = Resources.Potion__2_);
                                    Btn_Click(sender, e, Type.Item, Color.Gold, "I");
                                };
                                break;
                        }

                        this.Controls.Add(btn);

                        indice++;
                        btnX += btnWidth;
                    }

                    btnX = 0;
                    btnY += btnHeight;
                }

                Label lblHorizontal = new Label();
                lblHorizontal.Location = new Point(0, btnHeight * totalLinesSeparator);
                lblHorizontal.Width = btnWidth * totalColumns;
                lblHorizontal.Height = btnHeight;
                lblHorizontal.BackColor = Color.FromArgb(50, 50, 50);

                this.Controls.Add(lblHorizontal);

                btnX = 0;
                btnY = btnHeight * (totalLinesSeparator + 1);

                for (int i = 0; i < totalLinesSeparator; i++)
                {
                    for (int j = 0; j < totalColumns; j++)
                    {
                        btn = new Button();
                        btn.Location = new Point(btnX, btnY);
                        btn.Width = btnWidth;
                        btn.Height = btnHeight;
                        btn.BackColor = Color.White;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

                        switch (itens[indice])
                        {
                            case (Int32)Type.Terra:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Terra, btn.BackgroundImage = Resources.Grass);
                                    Btn_Click(sender, e, Type.Terra, Color.Green, "T");
                                };
                                break;
                            case (Int32)Type.Pedra:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Pedra, btn.BackgroundImage = Resources.Pedra);
                                    Btn_Click(sender, e, Type.Pedra, Color.Gray, "P");
                                };
                                break;
                            case (Int32)Type.Unidade1:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Unidade1, btn.BackgroundImage = Resources.Unity1__Up_);
                                    Btn_Click(sender, e, Type.Unidade1, Color.Blue, "U1");
                                };
                                break;
                            case (Int32)Type.Unidade2:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Unidade2, btn.BackgroundImage = Resources.Unity2__Up_);
                                    Btn_Click(sender, e, Type.Unidade2, Color.DarkOrange, "U2");
                                };
                                break;
                            case (Int32)Type.Unidade3:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Unidade3, btn.BackgroundImage = Resources.Unity3__Up__png);
                                    Btn_Click(sender, e, Type.Unidade3, Color.Red, "U3");
                                };
                                break;
                            case (Int32)Type.Item:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    //Btn_Click(sender, e, Type.Item, btn.BackgroundImage = Resources.Potion__2_);
                                    Btn_Click(sender, e, Type.Item, Color.Gold, "I");
                                };
                                break;
                        }

                        this.Controls.Add(btn);

                        indice++;
                        btnX += btnWidth;
                    }

                    btnX = 0;
                    btnY += btnHeight;
                }
            }
            this.btnClose.Visible = true;
        }
        public void SetVisible(bool visible)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new SetVisibleDelegate(SetVisible), new object[]
                {
                    visible
                });
            }
            else
            {
                this.Visible = visible;
            }
        }

        private void Btn_Click(object sender, System.EventArgs e, Type type, Color color, String text) //Image image)
        {
            //((Button)sender).BackgroundImage = image;
            ((Button)sender).BackColor = color;
            ((Button)sender).Text = text;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Você deseja realmente dar uma de cagão e desistir da partida?", "Surrender", MessageBoxButtons.YesNo);

            if (resposta == DialogResult.Yes)
            {
                this.Visible = false;
            }

        }
    }
}
