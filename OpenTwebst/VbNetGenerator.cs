﻿/*
 * This file is part of Open Twebst - web automation framework.
 * Copyright (c) 2012 Adrian Dorache
 * adrian.dorache@codecentrix.com
 *
 * Open Twebst is free software: you can redistribute it
 * and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version.
 *
 * Open Twebst is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Open Twebst. If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * Twebst can be used under a commercial license if such has been acquired
 * (see http://www.codecentrix.com/). The commercial license does not
 * cover derived or ported versions created by third parties under GPL.
 */

using System;
using System.Collections.Generic;
using System.Text;



namespace CatStudio
{
    class VbNetGenerator : BaseLanguageGenerator
    {
        public VbNetGenerator()
        {
            this.BACK_NAVIGATION_STATEMENT                  = "browser.nativeBrowser.GoBack()";
            this.FORWARD_NAVIGATION_STATEMENT               = "browser.nativeBrowser.GoForward()";
            this.START_UP_STATEMENT                         = "Dim core    As ICore    = New Core()\n" +
                                                              "Dim browser As IBrowser = core.StartBrowser(\"{0}\")\n";
            this.CLICK_NO_INDEX_STATEMENT                   = "browser.FindElement(\"{0}\", \"{1}={2}\").{3}";
            this.CLICK_NO_INDEX_NO_ATTR_STATEMENT           = "browser.FindElement(\"{0}\", \"\").{1}";
            this.CLICK_STATEMENT                            = "browser.FindElement(\"{0}\", \"{1}={2}, index={3}\").{4}";
            this.CLICK_NO_ATTR_STATEMENT                    = "browser.FindElement(\"{0}\", \"index={1}\").{2}";
            this.TEXT_CHANGED_NO_INDEX_STATEMENT            = "browser.FindElement(\"{0}\", \"{1}={2}\").InputText(\"{3}\")";
            this.TEXT_CHANGED_NO_INDEX_NO_ATTR_STATEMENT    = "browser.FindElement(\"{0}\", \"\").InputText(\"{1}\")";
            this.TEXT_CHANGED_STATEMENT                     = "browser.FindElement(\"{0}\", \"{1}={2}, index={3}\").InputText(\"{4}\")";
            this.TEXT_CHANGED_NO_ATTR_STATEMENT             = "browser.FindElement(\"{0}\", \"index={1}\").InputText(\"{2}\")";
            this.TEXT_CHANGED_ON_FILE_IE8_COMMENT           = "'Because of new HTML 5 security specifications, IE8 - IE9 does not reveal the real local path of the file you have selected. You have to manually change the code";
            this.SELECT_MULTIPLE_DECLARATION                = "Dim s As IElement\n";
            this.SELECT_MULTIPLE_FIRST_ITEM_STATEMENT       = "s.Select(\"{0}\")";
            this.SELECT_MULTIPLE_NO_INDEX_STATEMENT         = "{0}s = browser.FindElement(\"{1}\", \"{2}={3}\")\n";
            this.SELECT_MULTIPLE_NO_INDEX_NO_ATTR_STATEMENT = "{0}s = browser.FindElement(\"{1}\", \"\")\n";
            this.SELECT_MULTIPLE_STATEMENT                  = "{0}s = browser.FindElement(\"{1}\", \"{2}={3}, index={4}\")\n";
            this.SELECT_MULTIPLE_NO_ATTR_STATEMENT          = "{0}s = browser.FindElement(\"{1}\", \"index={2}\")\n";
            this.ADD_SELECTION_STATEMENT                    = "\ns.AddSelection(\"{0}\")";
            this.SELECT_NO_INDEX_STATEMENT                  = "browser.FindElement(\"{0}\", \"{1}={2}\").Select(\"{3}\")";
            this.SELECT_NO_INDEX_NO_ATTR_STATEMENT          = "browser.FindElement(\"{0}\", \"\").Select(\"{1}\")";
            this.SELECT_STATEMENT                           = "browser.FindElement(\"{0}\", \"{1}={2}, index={3}\").Select(\"{4}\")";
            this.SELECT_NO_ATTR_STATEMENT                   = "browser.FindElement(\"{0}\", \"index={1}\").Select(\"{2}\")";
        }


        protected override String EscapeStr(String source)
        {
            if (source == null)
            {
                return null;
            }

            String result = source.Replace("\"", "\"\"").Replace("\r\n", "\" & Microsoft.VisualBasic.ControlChars.CrLf & \"").Replace("\r", "\" & Microsoft.VisualBasic.ControlChars.Cr & \"").Replace("\n", "\" & Microsoft.VisualBasic.ControlChars.Lf & \"");
            return result;
        }


        internal override void Play(String code)
        {
            PlayDotNet(code, "VisualBasic", "OpenTwebstWebMacro");
        }


        internal override String FileExt
        {
            get { return ".vb"; }
        }


        internal override String DecorateCode(String code)
        {
            return String.Format(this.vbNetDecoration, IdentCode(code, 4));
        }


        public override string ToString()
        {
            return "VB.Net";
        }


        private readonly String vbNetDecoration = 
@"Imports System
Imports OpenTwebstLib
Imports SHDocVw

Module OpenTwebstWebMacro
    <STAThread()> _
    Sub Main()
    'Code generated by Open Twebst.
{0}
    End Sub
End Module
";
    }
}
