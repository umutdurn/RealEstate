import { useEffect, useState } from "react";
import GetEstateByFeatures from "./GetEstateByFeatures";
import EstateList from "./EstateList";

function ListFeatures({allFeatures}) {

    const[chckValue, setChckValue] = useState([]);

    useEffect(() => {

        if(chckValue.length > 0){

           var result = GetEstateByFeatures(chckValue.toString());

        }


    },[chckValue])

    const handleChange = (event) =>{

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
        
        <ul>
        
            {allFeatures.map((feature, index)=>{

                return <li key={index}>
                    <input type="checkbox" name="features" checked={ chckValue.includes(feature.id) } value={feature.id} onChange={handleChange} />
                    <label>{feature.title}</label>
                </li>;

            })}
            <li>{chckValue.toString()}</li>
        </ul>
        
     );
}

export default ListFeatures;