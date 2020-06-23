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
        private delegate void InitializeMatrixDelegate(int[] itens, int isFirst);
        private event EventHandler EnemyAttack;
        private enum Type
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
                MessageBox.Show("Aguardando outro jogador, ao encontrar, a partida será iniciada!");
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
                int btnWidth = 50;
                int btnHeight = 50;
                int btnX = 0;
                int btnY = 0;
                int indice = 0;
                MyButton btn;

                int totalLines = 14;
                int totalColumns = 25;
                int totalLinesSeparator = totalLines / 2;
                if (isFirst == 1)
                {
                    indice = (totalLines * totalColumns) / 2;
                }

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
                        btn.Line = i;
                        btn.Column = j;

                        // CAMPO DO INIMIGO
                        switch (itens[indice])
                        {
                            case (Int32)Type.Terra:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    Btn_Click_Enemy(sender, e, Type.Terra, btn.BackgroundImage = Resources.Terra);
                                };
                                break;
                            case (Int32)Type.Pedra:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    Btn_Click_Enemy(sender, e, Type.Pedra, btn.BackgroundImage = Resources.Pedra);
                                };
                                break;
                            case (Int32)Type.Unidade:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    if (isFirst == 0)
                                    {
                                        Btn_Click_Enemy(sender, e, Type.Unidade, btn.BackgroundImage = Resources.Unidade_Azul_Top);
                                    }
                                    else
                                    {
                                        Btn_Click_Enemy(sender, e, Type.Unidade, btn.BackgroundImage = Resources.Unidade_Vermelha_Top);
                                    }
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
                lblHorizontal.BackColor = Color.FromArgb(21, 108, 153);

                this.Controls.Add(lblHorizontal);
                //--------------------------------------------------------------------------------------------------------
                btnX = 0;
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
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    Btn_Click(sender, e, Type.Terra, btn.BackgroundImage = Resources.Terra);
                                };
                                break;
                            case (Int32)Type.Pedra:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    Btn_Click(sender, e, Type.Pedra, btn.BackgroundImage = Resources.Pedra);
                                };
                                break;
                            case (Int32)Type.Unidade:
                                btn.Click += (object sender, System.EventArgs e) =>
                                {
                                    if (isFirst == 1)
                                    {
                                        Btn_Click(sender, e, Type.Unidade, btn.BackgroundImage = Resources.Unidade_Azul_Bottom);
                                    }
                                    else
                                    {
                                        Btn_Click(sender, e, Type.Unidade, btn.BackgroundImage = Resources.Unidade_Vermelha_Bottom);
                                    }
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
                this.btnClose.Visible = true;

                MessageBox.Show("Que comecem os jogos!");
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

        private void Btn_Click_Enemy(object sender, System.EventArgs e, Type type, Image image)
        {
            ((MyButton)sender).BackgroundImage = image;
           
            if (this.EnemyAttack != null)
            {
                this.EnemyAttack.Invoke(this, new EnemyAttackEventArgs()
                {
                    Line = ((MyButton)sender).Line,
                    Column = ((MyButton)sender).Column
                });
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
