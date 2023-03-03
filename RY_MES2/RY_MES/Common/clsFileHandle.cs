﻿//**********************************************************************************************************************
//  Class Name  : clsFileHandle.cs
//  Description : 파일관리
//**********************************************************************************************************************
//  작성일자    : 2012.11
//  작 성 자    : 강병욱
//  Visual Studio   : 2008
//  .Net Framework  : v2.0.50727
//**********************************************************************************************************************
//  수정이력
//  2012.11 - Filehandle 생성시 경로의 파일 없으면 생성, Filehandle으로만 파일 접근
//  2014.07 - BinaryToFile ProgressBar 연동 추가
//
//**********************************************************************************************************************

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace nsCommon
{
    /// <summary>
    /// File을 다루기 위한 클레스
    /// </summary>
    public class Filehandle
    {
        #region [선언]

        public FileInfo _FileInfo;

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        //private string _FullName;

        #endregion [선언]

        #region 생성자 및 소멸자

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="FullName"></param>
        public Filehandle(string FullName)
        {
            _FileInfo = new FileInfo(FullName);
            if (!(_FileInfo.Exists))
            {
                FileCreate();
            }
            _FileInfo.Refresh();
        }

        public Filehandle(string FullName, bool Create)
        {
            _FileInfo = new FileInfo(FullName);
            if (!(_FileInfo.Exists) && Create)
            {
                FileCreate();
            }

            if (!_FileInfo.Directory.Exists)
            {
                CreateDirectory(_FileInfo.DirectoryName);
            }
            _FileInfo.Refresh();
        }

        #endregion 생성자

        #region 소멸자

        /// <summary>
        /// 소멸자
        /// </summary>
        ~Filehandle()
        {
            _FileInfo = null;
        }

        #endregion 소멸자

        #endregion 생성자 및 소멸자

        #region INI FILE Control(SetIniValue,GetIniValue)

        #region [Method] SetIniValue

        /// <summary>
        /// INI 파일의 해당 Section의 Key에 Value 값을 저장
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="Value">Value</param>
        /// <returns>WriteLength</returns>
        public long SetIniValue(string Section, string Key, string Value)
        {
            long WriteLength = WritePrivateProfileString(Section, Key, Value, _FileInfo.FullName);
            return WriteLength;
        }

        #endregion [Method] SetIniValue

        #region [Method] GetIniValue

        /// <summary>
        /// Section의 Key에 해당하는 값을 읽어옴
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <returns>Section의 Key에 해당하는 값이 문자열로 리턴
        /// Defalut = "" 이며 Defalut Size = 255로 설정
        /// </returns>
        public string GetIniValue(string Section, string Key)
        {
            return GetIniValue(Section, Key, "", 255);
        }

        /// <summary>
        /// Section의 Key에 해당하는 값을 읽어옴
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="Defalut">Defalut : 읽어오기 실패시 Defalut값</param>
        /// <returns>Section의 Key에 해당하는 값이 문자열로 리턴
        /// Defalut Size = 255로 설정
        /// </returns>
        public string GetIniValue(string Section, string Key, string Defalut)
        {
            return GetIniValue(Section, Key, Defalut, 255);
        }

        /// <summary>
        /// Section의 Key에 해당하는 값을 읽어옴
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="Defalut">Defalut : 읽어오기 실패시 Defalut값</param>
        /// <param name="Size">Size : 읽어올 용량(</param>
        /// <returns>Section의 Key에 해당하는 값이 문자열로 리턴 </returns>
        public string GetIniValue(string Section, string Key, string Defalut, int Size)
        {
            StringBuilder temp = new StringBuilder(Size);
            try
            {
                GetPrivateProfileString(Section, Key, "", temp, Size, _FileInfo.FullName);

                if (temp.ToString() == "")
                {
                    return Defalut;
                }
            }
            catch (Exception)
            {
                //Error.SystemError(this.ToString(), ex);
                return Defalut;
            }
            return temp.ToString();
        }

        #endregion [Method] GetIniValue

        #endregion INI FILE Control(SetIniValue,GetIniValue)

        #region File Info (FileCreate/ FileDelete)

        #region [Method] FileCreate

        /// <summary>
        /// (FileInfo)FullName의 파일을 생성한다. Directory가 없다면 Directory까지 모두 만든다.
        /// </summary>
        /// <param name="FullName"></param>
        /// <returns>Exception Message</returns>
        public string FileCreate()
        {
            try
            {
                FileInfo tmpFileInfo = new FileInfo(_FileInfo.FullName);

                if (!tmpFileInfo.Directory.Exists)
                {
                    string sException = CreateDirectory(tmpFileInfo.DirectoryName);
                    if (sException != null)
                    {
                        return sException;
                    }
                }
                if (!tmpFileInfo.Exists)
                {
                    FileStream fileStream = tmpFileInfo.Create();
                    fileStream.Close();
                }
                _FileInfo.Refresh();
            }
            catch (Exception ex)
            {
                _FileInfo.Refresh();
                return ex.Message;
            }
            return null;
        }

        #endregion [Method] FileCreate

        #region [Method] FileDelete

        /// <summary>
        /// (FileInfo)Filehandle생성시 경로의 파일을 영구적으로 삭제한다.
        /// </summary>
        /// <returns>Exception Message</returns>
        public string FileDelete()
        {
            try
            {
                if (_FileInfo.Exists)
                {
                    _FileInfo.Delete();
                }
                _FileInfo.Refresh();
            }
            catch (Exception ex)
            {
                _FileInfo.Refresh();
                return ex.Message;
            }
            return null;
        }

        #endregion [Method] FileDelete

        #endregion File Info (FileCreate/ FileDelete)

        #region StreamReader (ReadText,TextFileReadLine)

        #region [Method](StreamReader) ReadText

        /// <summary>
        /// (StreamReader)FullName에존재하는 Text파일의 전체내용을 UTF8 형식으로 불러온다. 실패시 NULL을 반환한다.
        /// </summary>
        /// <param name="FullName">FullName</param>
        /// <returns>Text파일의 전체내용을 UTF8 형식으로 불러온다. 실패시 NULL을 반환한다.</returns>
        public string ReadText()
        {
            string sFileRead = null;

            if (_FileInfo.Exists)
            {
                try
                {
                    StreamReader streamReader = _FileInfo.OpenText();
                    sFileRead = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return sFileRead;
        }

        /// <summary>
        /// (StreamReader)Filehandle생성시 경로에 존재하는 Text파일의 모든 Line을 UTF8 형식으로 불러온다. 실패시 NULL을 반환한다.
        /// </summary>
        /// <returns>한줄씩 string 배열에 넣어서 반환한다.</returns>
        public string[] TextFileReadLine()
        {
            string[] sFileRead = null;
            if (_FileInfo.Exists)
            {
                try
                {
                    StreamReader streamReader = _FileInfo.OpenText();
                    int iLineCnt = 0;
                    while (streamReader.ReadLine() != null)
                    {
                        iLineCnt++;
                    }

                    sFileRead = new string[iLineCnt];
                    streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    for (int i = 0; i < iLineCnt; i++)
                    {
                        sFileRead[i] = streamReader.ReadLine();
                    }
                    streamReader.Close();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return sFileRead;
        }

        /// <summary>
        /// (StreamReader)Filehandle생성시 경로에 존재하는 Text파일의 특정 Line을 UTF8 형식으로 불러온다. 실패시 NULL을 반환한다.
        /// </summary>
        /// <param name="Line"></param>
        /// <returns>한줄씩 string 배열에 넣어서 반환한다.</returns>
        public string TextFileReadLine(int Line)
        {
            string sFileRead = null;
            if (_FileInfo.Exists)
            {
                try
                {
                    StreamReader streamReader = _FileInfo.OpenText();
                    for (int i = 1; i < Line; i++)
                    {
                        streamReader.ReadLine();
                    }
                    sFileRead = streamReader.ReadLine();

                    streamReader.Close();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return sFileRead;
        }

        #endregion [Method](StreamReader) ReadText

        #endregion StreamReader (ReadText,TextFileReadLine)

        #region [Method](streamWriter) TextFileWrite

        /// <summary>
        /// (streamWriter)FullName에존재하는 Text파일에 Value값을 Append 한다. 실패시 Exception Message 반환 성공시 null 반환
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="FullName"></param>
        /// <returns> 실패시 Exception Message 반환 성공시 null 반환</returns>
        public string TextFileWriteAppend(string Value)
        {
            try
            {
                StreamWriter streamWriter = _FileInfo.AppendText();

                streamWriter.WriteLine(Value);
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        /// <summary>
        /// (streamWriter)FullName에존재하는 Text파일에 Value값을 Create 한다. 실패시 Exception Message 반환 성공시 null 반환
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="FullName"></param>
        /// <returns> 실패시 Exception Message 반환 성공시 null 반환</returns>
        public string TextFileWriteCreate(string Value, string FullName)
        {
            try
            {
                StreamWriter streamWriter = _FileInfo.CreateText();

                streamWriter.WriteLine(Value);
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        #endregion [Method](streamWriter) TextFileWrite

        #region [Method](FileStream) BinaryToFile

        /// <summary>
        /// (FileStream)FullName의 경로에 Byte[]를 파일로 저장한다.실패시 Exception Message 반환 성공시 null 반환
        /// </summary>
        /// <param name="BinaryData">Byte[]형식의 Binary Data</param>
        /// <param name="FullName">FullName 저장할 파일의 FullName</param>
        /// <returns>실패시 Exception Message 반환 성공시 null 반환</returns>
        public string BinaryToFile(byte[] BinaryData)
        {
            try
            {
                string FullName = _FileInfo.FullName;
                if (_FileInfo.Exists)
                {
                    _FileInfo.Delete();
                }

                FileStream fileStream = new FileStream(FullName, FileMode.Create, FileAccess.Write);
                fileStream.Write(BinaryData, 0, BinaryData.Length);

                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        #endregion [Method](FileStream) BinaryToFile

        #region [Method](FileStream) BinaryToFile

        /// <summary>
        /// (FileStream)FullName의 경로에 Byte[]를 파일로 저장한다.실패시 Exception Message 반환 성공시 null 반환
        /// ProgressBar 연동
        /// fileStream.Write 의 파라미터가 INT이기 때문에 2GByte 이상은 에러
        /// </summary>
        /// <param name="BinaryData">Byte[]형식의 Binary Data</param>
        /// <param name="FullName">FullName 저장할 파일의 FullName</param>
        /// <returns>실패시 Exception Message 반환 성공시 null 반환</returns>
        public string BinaryToFile(byte[] BinaryData, ref System.Windows.Forms.ProgressBar progressBar)
        {
            int tripWriteSize = 1024;
            int totalWriteSize = 0;
            try
            {
                string FullName = _FileInfo.FullName;
                if (_FileInfo.Exists)
                {
                    _FileInfo.Delete();
                }

                FileStream fileStream = new FileStream(FullName, FileMode.Create, FileAccess.Write);

                byte[] b = new byte[1024];

                double Percentage = 0;
                bool endoffile = false;

                while (endoffile == false)
                {
                    if (totalWriteSize + tripWriteSize > BinaryData.Length)
                    {
                        tripWriteSize = BinaryData.Length % 1024;
                        endoffile = true;
                    }
                    else if (totalWriteSize + tripWriteSize == BinaryData.Length)
                    {
                        endoffile = true;
                    }

                    fileStream.Write(BinaryData, totalWriteSize, tripWriteSize);
                    totalWriteSize += tripWriteSize;
                    Percentage = totalWriteSize / (BinaryData.Length / 100);

                    if (progressBar.Value != (int)Percentage)
                    {
                        progressBar.Value = (int)Percentage;
                        progressBar.Parent.Refresh();
                    }
                }

                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        #endregion [Method](FileStream) BinaryToFile

        #region [Method](FileStream) FileToBinary

        /// <summary>
        /// (FileStream)FullName의 경로에 파일을 Byte[]로 읽어온다.실패시 null 반환 성공시 Byte[] 반환
        /// </summary>
        /// <param name="FullName">FullName 저장할 파일의 FullName</param>
        /// <returns>실패시 Exception Message 반환 성공시 null 반환</returns>
        public byte[] FileToBinary()
        {
            try
            {
                byte[] bytes = new byte[int.Parse(_FileInfo.Length.ToString())];
                FileStream fileStream = new FileStream(_FileInfo.FullName, FileMode.Open, FileAccess.Read);
                fileStream.Read(bytes, 0, int.Parse(_FileInfo.Length.ToString()));

                fileStream.Flush();
                fileStream.Close();
                return bytes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion [Method](FileStream) FileToBinary

        #region [Method] CreateDirectory

        /// <summary>
        /// Directory Create 중간경로까지 없으면 모두 생성하여 준다.
        /// </summary>
        /// <param name="DirectoryName">CreateDirectory</param>
        /// <returns>실패시 Exception Message 반환 성공시 null 반환</returns>
        public string CreateDirectory(string DirectoryName)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryName);
                string[] Parent = directoryInfo.FullName.Split('\\');
                string FullDirectoryName = Parent[0];
                for (int i = 1; i < Parent.Length; i++)
                {
                    FullDirectoryName = FullDirectoryName + '\\' + Parent[i];
                    if (!Directory.Exists(FullDirectoryName))
                    {
                        Directory.CreateDirectory(FullDirectoryName);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion [Method] CreateDirectory
    }
}