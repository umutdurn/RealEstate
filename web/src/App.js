
import './App.css';
import EstateList from './EstateList';
import LoadEstate from './LoadEstate';
import EstateFilter from './EstateFilter';
import LoadEstateByTitle from './LoadEstateByTitle';
import SearchHeader from './SearchHeader';
import LoadEstateRange from './LoadEstateRange';
import GetAllFeatures from './GetAllFeatures';
import GetEstateByFeatures from "./GetEstateByFeatures";

import { useEffect, useState } from 'react';

function App() {

  const[data, setData] = useState([]);
  const[dataFeature, setDataFeature] = useState([]);
  const[chckValue, setChckValue] = useState([]);

  const handleSubmit = async (term) => {

    if(term != ""){

      const result = await LoadEstateByTitle(term);

      setData(result);

    }else{

      const result = await LoadEstate(term);

      setData(result);

    }

  }

  const handleFilter = async (min,max) =>{

    if(min != "" || max != ""){

      const result = await LoadEstateRange(min,max);

      setData(result);

    }

  }

  useEffect(() => {

    handlerFeatures();
   
  },[])

  const handlerFeatures = async () =>{

    const result = await GetAllFeatures();

    setDataFeature(result);

  }


useEffect(() => {

  if(chckValue.length > 0){

    var fetcData = async () =>{

      var result = await GetEstateByFeatures(chckValue.toString());

      setData(result.data);

    }

    fetcData();

   }else if(chckValue.length == 0){

    var fetcData = async () =>{

      var result = await await LoadEstate(null);

      setData(result);

    }

    fetcData();

   }

},[chckValue])

const handleChange = async (event) =>{

    let isSeledted = event.target.checked;
    let value = parseInt(event.target.value);

    if(isSeledted){

        setChckValue([...chckValue, value]);

    }else{

        setChckValue((prevData) => {

            return prevData.filter((id => {

                return id !== value;

            }))

        })

    }

}

  return (
    <div className="App">
      <SearchHeader search={handleSubmit}/>
      <div className="row">
        <div className="left">
          <EstateFilter filter={handleFilter} />
          <span>Özellikler</span>
            <ul>
                {dataFeature.map((feature, index)=>{

                    return <li key={index}>
                        <input type="checkbox" name="features" checked={ chckValue.includes(feature.id) } value={feature.id} onChange={handleChange} />
                        <label>{feature.title}</label>
                    </li>;

                })}
              <li>{chckValue.toString()}</li>
          </ul>
        </div>
        <div className="right">
          <EstateList getAllEstate={data} />
        </div>
      </div>
    </div>
  );
}

export default App;
