using System;
using System.Drawing;
using System.Windows.Forms;
using Core;
using QMag.Controls;
using QMag.Core;

namespace Controls.Checkbox
{
    public partial class RoundedCheckbox : UserControl
    {
        private readonly Element _element;

        private bool _state;

        private readonly Color _offColor = Color.FromArgb(238, 83, 79);
        private readonly Color _onColor = Color.FromArgb(76, 176, 80);
        private readonly Color _disqueColor = Color.FromArgb(230, 230, 230);

        private int _positionDebut;
        private int _positionFin;

        private const float TailleTexte = 12.5f;

        private const int VitesseAnimation = 2;
        public RoundedCheckbox()
        {
            InitializeComponent();

            _element = new Element(pictureBox);

            InitialiseCadre();
            InitialiseCercle();
            TexteOff();
            PositionFinale(_state, true);

            ResizeControl(null, null);
        }

        private void TexteOff()
        {
            _element.Dimensionne(TailleTexte);
            _element.Positionne(
                _element.Dimension("Bouton").X - 35,
                _element.Position("Disque").Y - 2
            );
            
            _element.AjouterTexte("Label", "Off", _disqueColor, FontStyle.Bold);
        }
        private void TexteOn()
        {
            _element.Dimensionne(TailleTexte);
            _element.Positionne(
                5,
                _element.Position("Disque").Y - 2
            );

            _element.AjouterTexte("Label", "On", _disqueColor, FontStyle.Bold);
        }

        private void InitialiseCadre()
        {
            _element.Dimensionne(70, 30);
            _element.AjouterRectangleArrondi("Bouton", _element.GetDimension.Yi / 2, _offColor);
        }

        private void InitialiseCercle()
        {
            _element.Dimensionne(20);
            _element.Positionne(
                10,
                (_element.Dimension("Bouton").Y - _element.GetDimension.Y) / 2
                );

            _element.AjouterDisque("Disque", _disqueColor);

            _positionDebut = _element.GetPosition.Xi;
            _positionFin = _element.Dimension("Bouton").Xi - _positionDebut - _element.GetDimension.Xi;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            _element.Affiche(e.Graphics);
        }

        private void PositionFinale(bool state, bool invalidate)
        {
            if (!state)
            {
                _element.Position("Disque").X = _positionDebut;
                _element.GetFigure("Bouton").SetBrosse(_offColor);

                _element.Remove("Label");
                TexteOff();
            }
            else
            {
                _element.Position("Disque").X = _positionFin;
                _element.GetFigure("Bouton").SetBrosse(_onColor);

                _element.Remove("Label");
                TexteOn();
            }

            if(invalidate)
                pictureBox.Invalidate();
        }

        private void timerSlide_Tick(object sender, EventArgs e)
        {
            if (_state)
            {
                _element.Deplace("Disque", -VitesseAnimation);

                if (_element.Position("Disque").X <= _positionDebut)
                {
                    timerSlide.Stop();
                    _state = false;
                    PositionFinale(_state, false);
                }
            }
            else
            {
                _element.Deplace("Disque", VitesseAnimation);

                if (_element.Position("Disque").X >= _positionFin)
                {
                    timerSlide.Stop();
                    _state = true;
                    PositionFinale(_state, false);
                }
            }

            pictureBox.Invalidate();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            timerSlide.Start();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor.Current != Cursors.Hand)
                Cursor.Current = Cursors.Hand;
        }

        private void ResizeControl(object sender, EventArgs e)
        {
            Couple nouvelleTaille = new Couple(pictureBox.Location.X, (Height - pictureBox.Height) / 2);
            pictureBox.Location = nouvelleTaille.ToPoint();
        }

        public bool State
        {
            get => _state;
            set
            {
                _state = value;
                PositionFinale(_state, true);
            }
        }
    }
}
