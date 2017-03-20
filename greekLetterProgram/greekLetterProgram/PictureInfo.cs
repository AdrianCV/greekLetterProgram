using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greekLetterProgram
{
    class PictureInfo
    {
        private string letterName;
        private string upperCaseLetterLink;
        private string lowerCaseLetterLink;

        public PictureInfo(string letter, string upper, string lower)
        {
            letterName = letter;
            upperCaseLetterLink = upper;
            lowerCaseLetterLink = lower;
        }

        public string LetterName
        {
            get { return letterName; }
            set { letterName = value; }
        }

        public string UpperLink
        {
            get { return upperCaseLetterLink; }
            set { upperCaseLetterLink = value; }
        }

        public string LowerLink
        {
            get { return lowerCaseLetterLink; }
            set { lowerCaseLetterLink = value; }
        }
    }
}
