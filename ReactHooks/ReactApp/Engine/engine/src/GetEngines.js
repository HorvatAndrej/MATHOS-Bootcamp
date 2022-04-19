import React, { useEffect, useState } from "react";
import axios from 'axios';

export default function GetEngines() {


    const [engines, getEngines] = useState([]);   

    const getAllEngines = () => {
        axios.get('https://localhost:44379/api/engine/get?sortOrder=desc&columnName=Name&pageNumber=2&objectsPerPage=2&id=&name=').then((response)=>{
            
            getEngines(response.data);
        })
        .catch(error => console.error('Error!'));
    }

      return (
        <div>
            <button onClick={getAllEngines}> Get engines </button>
        <pre>
        {engines.map(engine=><li>{engine.Name} {engine.Type} </li>)}
        </pre>
        </div>
  
  
      );
    }