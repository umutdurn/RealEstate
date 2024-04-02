import { useEffect, useState } from 'react';

function SearchHeader({search}) {

    const[valueInput, setValueInput] = useState('');

     useEffect(() => {

        search(valueInput);

    },[valueInput])


    const handleChange = (event) =>{

        setValueInput(event.target.value);
        
    }

    return ( 
        <>
        <div className="searchHeader">
            <form >
                <span>Real Estate</span>
                <input placeholder="Ara..." value={valueInput}  onChange={(handleChange)} />
            </form>
        </div>
        </>
     );
}

export default SearchHeader;