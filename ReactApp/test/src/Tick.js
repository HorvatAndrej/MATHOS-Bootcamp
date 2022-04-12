import ReactDOM from 'react-dom'
import React from 'react'
import "./App.css"


const root = ReactDOM.createRoot(
    document.getElementById('root')
  );
  
  function Tick(){
  
    
    const element = (
        <div className="header">
          <h1>Hello, world!</h1>
          <h2>It is {new Date().toLocaleTimeString()}.</h2>
        </div>
      )
      
    return element;
     
  }
  
  setInterval(Tick, 1000);

  export default Tick;