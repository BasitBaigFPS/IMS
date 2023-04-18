function userValid() {

    var Name, gender, text1 ,con, EmailId, emailExp;

 

    Name = document.getElementById("txtUserId").value;

    gender = document.getElementById("ddlType").value;

    text1  = document.getElementById("txt1").value;

    con = document.getElementById("txt2").value;

    EmailId = document.getElementById("txtmail").value;

    emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id

 

    if (Name == '' && gender == 0 && text1 == '' && con == '' && EmailId == '') {

        alert("Enter All Fields");

        return false;

    }

    if (Name == '') {

        alert("Please Enter Login ID");

        return false;

    }

    if (gender == 0) {

        alert("Please Select gender");

        return false;

    }

    if (text1 == '')

    {

        alert("Please Enter word");

        return false;

    }

    if (text1 != '' && con == '')

    {

        alert("Please Confirm word");

        return false;

    }

    if ( con != con)

    {
        alert("word not match");
        return false;
    }

    if (EmailId == '')

    {
        alert("Email Id Is Required");
        return false;
    }

    if (EmailId != '')

    {
        if (!EmailId.match(emailExp))

        {
            alert("Invalid Email Id");
            return false;
        }
    }

    return true;

}