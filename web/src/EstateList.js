import Estate from './Estate'

function EstateList({getAllEstate}) {

    return ( 
        
        <>
            {getAllEstate?.map((estate, index)=>{

                return <Estate key={index} estateInfo={estate} />;

            })}
        </>

     );
}


export default EstateList;