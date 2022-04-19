import React, { useEffect, useState } from "react";
import axios from 'axios';

export default function GetEngineById() {


    const [engines, getEngine] = useState([]);   

    const getEngineById = (event) => {
        event.preventDefault();
        let info = document.forms["engineForm"]["engine"].value;
        console.log(info);
        axios.get(`https://localhost:44379/api/engine/getbyid?id=${info}`).then((response)=>{
            console.log(response.data);
            getEngine(response.data);
        })
        .catch(error => console.error('Error!'));
    }
   

      return (
        <div>
            <form >
          <ul>
          <li>
          <textarea  ></textarea>
          </li>  
          </ul>
          
          <input type="submit" onClick={getEngineById}></input>
          </form>

        <pre>
        {engines.map(engine=><li>{engine.Name} {engine.Type}</li>)}
        </pre>
        </div>
  
  
      );
    }