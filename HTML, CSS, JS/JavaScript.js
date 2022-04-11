
function ShowAnswer(form)
{
    
    const btn = document.querySelector('#btn');        
        const radioButtons = document.querySelectorAll('input[name="yes_no"]');
        btn.addEventListener("click", () => {
            let selectedAnswer;
            for (const radioButton of radioButtons) {
                if (radioButton.checked) {
                    selectedAnswer = radioButton.value;
                    break;
                }
            }
            // show the output:
            return output.innerText = selectedAnswer ? `You selected ${selectedAnswer}` : `You haven't selected an option`;
        }
        )
}    
         

function DropdownFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
  }
  
  // Close the dropdown if the user clicks outside of it
  window.onclick = function(event) {
    if (!event.target.matches('.dropbtn')) {
      var dropdowns = document.getElementsByClassName("dropdown-content");
      var i;
      for (i = 0; i < dropdowns.length; i++) {
        var openDropdown = dropdowns[i];
        if (openDropdown.classList.contains('show')) {
          openDropdown.classList.remove('show');
        }
      }
    }
  }

  function validateForm()                                    
  { 
      var name = document.forms["myForm"]["name"];               
      var email = document.forms["myForm"]["email"];    
      var message = document.forms["myForm"]["message"];   
     
      if (name.value == "")                                  
      { 
          document.getElementById('errorname').innerHTML="Please enter a valid name";  
          name.focus(); 
          return false; 
      }else{
          document.getElementById('errorname').innerHTML="";  
      }
         
      if (email.value == "")                                   
      { 
          document.getElementById('erroremail').innerHTML="Please enter a valid email address"; 
          email.focus(); 
          return false; 
      }else{
          document.getElementById('erroremail').innerHTML="";  
      }
     
      if (email.value.indexOf("@", 0) < 0)                 
      { 
          document.getElementById('erroremail').innerHTML="Please enter a valid email address"; 
          email.focus(); 
          return false; 
      } 
     
      if (email.value.indexOf(".", 0) < 0)                 
      { 
          document.getElementById('erroremail').innerHTML="Please enter a valid email address"; 
          email.focus(); 
          return false; 
      } 
     
      if (message.value == "")                           
      {
          document.getElementById('errormsg').innerHTML="Please enter a valid message"; 
          message.focus(); 
          return false; 
      }else{
          document.getElementById('errormsg').innerHTML="";  
      }
     
      return true; 
  }