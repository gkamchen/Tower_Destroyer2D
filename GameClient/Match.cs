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
        private enum Type
        {
            Terra,
            Pedra,
            Item,
            Unidade1,
            Unidade2,
            Unidade3
        }


        public Match()
        {
            InitializeComponent();
            InicializarMatriz();
        }

        private int[] InitializeArrayWithNoDuplicates(int size)
        {
            Random rand = new Random();

            return Enumerable.Repeat<int>(0, size).Select((value, index) => new { i = index, rand = rand.Next() }).OrderBy(x => x.rand).Select(x => x.i).ToArray();
        }

        private void InicializarMatriz()
        {
            int qtdUnidade1 = 80;
            int qtdUnidade2 = 60;
            int qtdUnidade3 = 40;
            int qtdItens = 20;
            int qtdPedra = 50;
            int qtdTerra = 100;
            int qtdPosicoes = 350;

            int index = 0;
            int[] indexes = InitializeArrayWithNoDuplicates(qtdPosicoes / 2);

            dynamic[] itens = new dynamic[qtdPosicoes / 2];

            for (int i = 0; i < qtdUnidade1 / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Unidade1 };
            }

            for (int i = 0; i < qtdUnidade2 / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Unidade2 };
            }

            for (int i = 0; i < qtdUnidade3 / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Unidade3 };
            }

            for (int i = 0; i < qtdTerra / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Terra };
            }

            for (int i = 0; i < qtdPedra / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Pedra };
            }

            for (int i = 0; i < qtdItens / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Item };
            }
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

                    switch (itens[indice].type)
                    {
                        case Type.Terra:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Terra, btn.BackgroundImage = Resources.Grass);
                                Btn_Click(sender, e, Type.Terra, Color.Green, "T");
                            };
                            break;
                        case Type.Pedra:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Pedra, btn.BackgroundImage = Resources.Pedra);
                                Btn_Click(sender, e, Type.Pedra, Color.Gray, "P");
                            };
                            break;
                        case Type.Unidade1:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Unidade1, btn.BackgroundImage = Resources.Unity1__Up_);
                                Btn_Click(sender, e, Type.Unidade1, Color.Blue, "U1");
                            };
                            break;
                        case Type.Unidade2:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Unidade2, btn.BackgroundImage = Resources.Unity2__Up_);
                                Btn_Click(sender, e, Type.Unidade2, Color.DarkOrange, "U2");
                            };
                            break;
                        case Type.Unidade3:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Unidade3, btn.BackgroundImage = Resources.Unity3__Up__png);
                                Btn_Click(sender, e, Type.Unidade3, Color.Red, "U3");
                            };
                            break;
                        case Type.Item:
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

            index = 0;
            indexes = InitializeArrayWithNoDuplicates(qtdPosicoes / 2);

            itens = new dynamic[qtdPosicoes / 2];
            for (int i = 0; i < qtdUnidade1 / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Unidade1 };
            }

            for (int i = 0; i < qtdUnidade2 / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Unidade2 };
            }

            for (int i = 0; i < qtdUnidade3 / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Unidade3 };
            }

            for (int i = 0; i < qtdTerra / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Terra };
            }

            for (int i = 0; i < qtdPedra / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Pedra };
            }

            for (int i = 0; i < qtdItens / 2; i++)
            {
                itens[indexes[index++]] = new { type = Type.Item };
            }

            btnX = 0;
            btnY = btnHeight * (totalLinesSeparator + 1);

            indice = 0;

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

                    switch (itens[indice].type)
                    {
                        case Type.Terra:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Terra, btn.BackgroundImage = Resources.Grass);
                                Btn_Click(sender, e, Type.Terra, Color.Green, "T");
                            };
                            break;
                        case Type.Pedra:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Pedra, btn.BackgroundImage = Resources.Pedra);
                                Btn_Click(sender, e, Type.Pedra, Color.Gray, "P");
                            };
                            break;
                        case Type.Unidade1:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Unidade1, btn.BackgroundImage = Resources.Unity1__Up_);
                                Btn_Click(sender, e, Type.Unidade1, Color.Blue, "U1");
                            };
                            break;
                        case Type.Unidade2:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Unidade2, btn.BackgroundImage = Resources.Unity2__Up_);
                                Btn_Click(sender, e, Type.Unidade2, Color.DarkOrange, "U2");
                            };
                            break;
                        case Type.Unidade3:
                            btn.Click += (object sender, System.EventArgs e) =>
                            {
                                //Btn_Click(sender, e, Type.Unidade3, btn.BackgroundImage = Resources.Unity3__Up__png);
                                Btn_Click(sender, e, Type.Unidade3, Color.Red, "U3");
                            };
                            break;
                        case Type.Item:
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
