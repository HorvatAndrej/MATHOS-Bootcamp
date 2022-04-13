import React from "react";
import "./App.css"



function Button() {
    return (
      <>
      <div class="header">
        <p>Neki kao gumb</p>
            <p>↓</p>
            <p>↓</p>
        <button className="btn btn-primary" onClick={() => alert("Neki kao gumb ne radi ništa")}>Neki kao gumb</button>
        </div>
      </>
      );
  }

  export default Button;

  