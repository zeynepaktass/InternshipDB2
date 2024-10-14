//Box
    var warningWindow = document.getElementById("warningWindow");
    var yesButton = document.getElementById("yesButton");
    var noButton = document.getElementById("noButton");

    function showWarning() {
        warningWindow.style.display = "block";
    }

    function hideWarning() {
        warningWindow.style.display = "none";
    }
    function confirmDelete() {
        showWarning();
        yesButton.onclick = function () {
            hideWarning();
        }
        noButton.onclick = function () {
            hideWarning();
        }
    }
	
//Reset function	
function confirmReset() {
    var studentNo = document.getElementById("studentNo").value;
    console.log(studentNo)
	showWarning();
	
    yesButton.onclick = function () {
          var inputs = document.querySelectorAll('#myForm input');
		  inputs.forEach(function(input) {
			input.value = '';
			var submit = document.getElementById('Submit');
			submit.value='Submit';
			document.getElementById("mandatory").checked = false;
              document.getElementById("volunteer").checked = false;
              document.getElementById("studentNo").value = studentNo;
		  });
            hideWarning();
        }
        noButton.onclick = function () {
            hideWarning();
        }
		
	
}

//Form validation
function validateForm() {
  var mandatoryRadio = document.getElementById("mandatory");
  var volunteerRadio = document.getElementById("volunteer");

  if (!mandatoryRadio.checked && !volunteerRadio.checked) {
      alert("Internship type must be checked");
      return false;
  }

  var startDate = document.getElementById("startDate");
  if(startDate.value==""){
	alert("Start date must be choosen");
	return false;
  }

  var finishDate = document.getElementById("finishDate");
  if(finishDate.value==""){
	alert("Finish date must be choosen");
	return false;
  }

  var file=document.getElementById("myFile");
  if(file.value=="") {
	alert("File must be choosen");
	return false;
  }

  let SN = document.forms["myForm"]["Name"].value;
  if (SN == null || SN == "") {
    alert("Name must be filled out");
    return false;
  }
  
  let CN = document.forms["myForm"]["CompanyName"].value;
  if (CN == null || CN == "") {
    alert("Company name must be filled out");
    return false;
  }
  
  let CRN = document.forms["myForm"]["CompanyRepresentativeName"].value;
  if (CRN == null || CRN == "") {
    alert("Company representative name must be filled out");
    return false;
  }
  
  let SS = document.forms["myForm"]["Surname"].value;
  if (SS == null || SS == "") {
    alert("Surname must be filled out");
    return false;
  }
  
  let CF = document.forms["myForm"]["CompanyField"].value;
  if (CF == null || CF == "") {
    alert("Company field must be filled out");
    return false;
  }
  
  let CRS = document.forms["myForm"]["CompanyRepresentativeSurname"].value;
  if (CRS == null || CRS == "") {
    alert("Company representative surname must be filled out");
    return false;
  }
  
  let EM = document.forms["myForm"]["Email"].value;
  if (EM == null || EM == "") {
    alert("Email must be filled out");
    return false;
  }
  
  let CEM = document.forms["myForm"]["CompanyEmail"].value;
  if (CEM == null || CEM == "") {
    alert("Company email must be filled out");
    return false;
  }
  
  let CREM = document.forms["myForm"]["CompanyRepresentativeEmail"].value;
  if (CREM == null || CREM == "") {
    alert("Company representative email must be filled out");
    return false;
  }
  
  let SPN = document.forms["myForm"]["Phone"].value;
  if (SPN == null || SPN == "") {
    alert("Phone number must be filled out");
    return false;
  }
  
  let CPN = document.forms["myForm"]["CompanyPhone"].value;
  if (CPN == null || CPN == "") {
    alert("Company phone number must be filled out");
    return false;
  }
  
  let CRPN = document.forms["myForm"]["CompanyRepresentativePhone"].value;
  if (CRPN == null || CRPN == "") {
    alert("Company representative phone number must be filled out");
    return false;
  }
  
  let SA = document.forms["myForm"]["Address"].value;
  if (SA == null || SA == "") {
    alert("Address must be filled out");
    return false;
  }
  
  let CA = document.forms["myForm"]["CompanyAddress"].value;
  if (CA == null || CA == "") {
    alert("Company address must be filled out");
    return false;
  }
  
  let SD = document.forms["myForm"]["Department"].value;
  if (SD == null || SD == "") {
    alert("Department must be filled out");
    return false;
  }
  
}

