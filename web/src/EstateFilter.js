import { useEffect, useState } from "react";

function EstateFilter({filter}) {

    const[minimum, setMinimum] = useState('');
    const[maximum, setMaximum] = useState('');

    useEffect(() => {

        filter(minimum,maximum);

    },[minimum,maximum])


    const MiniHandler = (event) => {

        setMinimum(event.target.value);

    }

    const MaxHandler = (event) =>{

        setMaximum(event.target.value);

    }

    return ( 

        <>
        
        <div>
            <span>Fiyat Aralığı</span>
            <div>
                <input placeholder="Minimum" value={minimum} onChange={MiniHandler} />
            </div>
            <div>
                <input placeholder="Maksimum" value={maximum}  onChange={MaxHandler} />
            </div>
        </div>

        </>

     );
}

export default EstateFilter;