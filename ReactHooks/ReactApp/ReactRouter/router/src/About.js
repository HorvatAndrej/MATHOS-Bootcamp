import './App.css';
import React, {useState, useEffect} from 'react';

function About() {

  useEffect(()=>{
    fetchItems();
  },[]);

  const[items, setItems]=useState([]);

  const fetchItems= async()=>{
    const data= await fetch('https://localhost:44379/api/engine/get?sortOrder=desc&columnName=Name&pageNumber=2&objectsPerPage=2&id=&name=');
    const item= await data.json();
  setItems(item);
  };
  
  return (
    <div>
      <h1>About</h1>
      {items.map(item=>(
        <h1>{item.Name}</h1>
      ))};
    </div>
  );
}

export default About;
