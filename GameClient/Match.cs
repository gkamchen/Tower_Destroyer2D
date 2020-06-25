using GameClient.EventArgs;
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
        private delegate void WaitPlayerDelegate();
        private delegate void ShowMyButtonEnemyClickDelegate(int line, int column);
        private delegate void InitializeMatrixDelegate(int[] itens, int isFirst);
        private event EventHandler EnemyAttack;
        private MyButton[,] myButtons;
        public enum Type
        {
            Terra = 1,
            Pedra = 2,
            Item = 3,
            Unidade = 4
        }

        public Match(EventHandler EnemyAttack)
        {
            InitializeComponent();
            this.EnemyAttack = EnemyAttack;
        }

        private int[] InitializeArrayWithNoDuplicates(int size)
        {
            Random rand = new Random();

            return Enumerable.Repeat<int>(0, size).Select((value, index) => new { i = index, rand = rand.Next() }).OrderBy(x => x.rand).Select(x => x.i).ToArray();
        }

        public void WaitPlayer()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new WaitPlayerDelegate(WaitPlayer), new object[] { });
            }
            else
            {
                //MessageBox.Show("Aguardando outro jogador, ao encontrar, a partida será iniciada!");
            }
        }
        public void ShowMyButtonEnemyClick(int line, int column)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new ShowMyButtonEnemyClickDelegate(ShowMyButtonEnemyClick), new object[]
                {
                    line,
                    column
                });
            }
            else
            {
                MyButton btn = this.myButtons[line, column];

                btn.BackgroundImage = btn.Item;
                this.Enabled = true;

            }
        }

        public void InitializeMatrix(int[] itens, int isFirst)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new InitializeMatrixDelegate(InitializeMatrix), new object[]
                {
                    itens,
                    isFirst
                });
            }
            else
            {
                MyButton btn;
                int btnWidth = 50;
                int btnHeight = 50;
                int btnX = 0;
                int indice = 0;

                int totalLines = 14;
                int totalColumns = 25;
                int totalLinesSeparator = totalLines / 2;
                if (isFirst == 1)
                {
                    indice = (totalLines * totalColumns) / 2;
                }
                else
                {
                    this.Enabled = false;
                }

                int btnY = btnHeight * (totalLinesSeparator - 1);

                // CAMPO DO INIMIGO
                for (int i = 0; i < totalLinesSeparator; i++)
                {
                    for (int j = 0; j < totalColumns; j++)
                    {
                        btn = new MyButton();
                        btn.Location = new Point(btnX, btnY);
                        btn.Width = btnWidth;
                        btn.Height = btnHeight;
                        btn.BackgroundImage = Resources.Fundo;
                        btn.BackgroundImageLayout = ImageLayout.Zoom;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btn.MouseEnter += new EventHandler(this.btn_MouseEnter);
                        btn.MouseLeave += new EventHandler(this.btn_MouseLeave);
                        btn.Line = i;
                        btn.Column = j;

                        // CAMPO DO INIMIGO
                        switch (itens[indice])
                        {
                            case (Int32)Type.Terra:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    Btn_Click_Enemy(sender, e, Resources.Terra);
                                };
                                break;
                            case (Int32)Type.Pedra:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    Btn_Click_Enemy(sender, e, Resources.Pedra);
                                };
                                break;
                            case (Int32)Type.Unidade:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    if (isFirst == 0)
                                    {
                                        Btn_Click_Enemy(sender, e, Resources.Unidade_Azul_Top_Queb);
                                    }
                                    else
                                    {
                                        Btn_Click_Enemy(sender, e, Resources.Unidade_Vermelha_Top_Queb);
                                    }
                                };
                                break;
                        }

                        this.Controls.Add(btn);

                        indice++;
                        btnX += btnWidth;
                    }

                    btnX = 0;
                    btnY -= btnHeight;
                }
                //-------------------------------------------------------------------------------------------------------
                // Separador de campos
                Label lblHorizontal = new Label();
                lblHorizontal.Location = new Point(0, btnHeight * totalLinesSeparator);
                lblHorizontal.Width = btnWidth * totalColumns;
                lblHorizontal.Height = btnHeight;
                lblHorizontal.BackgroundImage = Resources.Lago;
                lblHorizontal.BackgroundImageLayout = ImageLayout.Zoom;

                this.Controls.Add(lblHorizontal);
                //--------------------------------------------------------------------------------------------------------
                btnX = 0;
                myButtons = new MyButton[totalLinesSeparator, totalColumns];
                btnY = btnHeight * (totalLinesSeparator + 1);
                if (isFirst == 1)
                {
                    indice = 0;
                }
                // MEU CAMPO
                for (int i = 0; i < totalLinesSeparator; i++)
                {
                    for (int j = 0; j < totalColumns; j++)
                    {
                        btn = new MyButton();
                        btn.Location = new Point(btnX, btnY);
                        btn.Width = btnWidth;
                        btn.Height = btnHeight;
                        btn.BackgroundImage = Resources.Fundo;
                        btn.BackgroundImageLayout = ImageLayout.Zoom;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btn.Enabled = false;
                        btn.Line = i;
                        btn.Column = j;
                        


                        // MEU CAMPO
                        switch (itens[indice])
                        {
                            case (Int32)Type.Terra:
                                btn.Type = Type.Terra;
                                btn.Item = Resources.Terra;
                                break;
                            case (Int32)Type.Pedra:
                                btn.Type = Type.Pedra;
                                btn.Item = Resources.Pedra;
                                break;
                            case (Int32)Type.Unidade:
                                btn.Enabled = true;
                                btn.Type = Type.Unidade;
                                if (isFirst == 1)
                                {
                                    btn.BackgroundImage = Resources.Unidade_Azul_Bottom;
                                    btn.Item = Resources.Unidade_Azul_Bottom_Queb;
                                }
                                else
                                {
                                    btn.BackgroundImage = Resources.Unidade_Vermelha_Bottom;
                                    btn.Item = Resources.Unidade_Vermelha_Bottom_Queb;
                                }
                                break;
                        }

                        this.Controls.Add(btn);
                        myButtons[i, j] = btn;

                        indice++;
                        btnX += btnWidth;
                    }

                    btnX = 0;
                    btnY += btnHeight;

                }
                this.btnClose.Visible = true;

            }

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

        private void Btn_Click(object sender, System.EventArgs e, Type type, Image image)
        {
            ((MyButton)sender).BackgroundImage = image;
        }

        private void Btn_Click_Enemy(object sender, System.EventArgs e, Image image)
        {

            if (this.EnemyAttack != null)
            {
                ((MyButton)sender).BackgroundImage = image;
                ((MyButton)sender).BackColor = Color.Transparent;
                ((MyButton)sender).Enabled = false;
                this.EnemyAttack.Invoke(this, new EnemyAttackEventArgs()
                {
                    Line = ((MyButton)sender).Line,
                    Column = ((MyButton)sender).Column
                });
                this.Enabled = false;
            }
        }
        private void btn_MouseEnter(object sender, System.EventArgs e)
        {
            MyButton enterButton = (MyButton)sender;
            if (enterButton.Enabled == true)
            {
                enterButton.BackgroundImage = Resources.Fundo_Alvo;
                enterButton.BackColor = Color.Red;
                enterButton.FlatAppearance.MouseDownBackColor = Color.Red;
                enterButton.FlatAppearance.MouseOverBackColor = Color.Red;
            }

        }

        private void btn_MouseLeave(object sender, System.EventArgs e)
        {
            MyButton leaveMouseButton = (MyButton)sender;
            if (leaveMouseButton.Enabled == true)
            {
                leaveMouseButton.BackgroundImage = Resources.Fundo;
                leaveMouseButton.BackColor = Color.Transparent;
                leaveMouseButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                leaveMouseButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            }

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
