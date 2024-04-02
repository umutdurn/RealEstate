function Estate({estateInfo}) {
    return ( 

        <>
            <div className="estateBox">
                <h3>{estateInfo.title}</h3>
                <img src={estateInfo.image} />
                <div>
                    <span>Fiyatı: {estateInfo.price}</span>
                    <span>Metrekare: {estateInfo.m2}</span>
                    <span>Kat: {estateInfo.floor}</span>
                    <div className="clearfix"></div>
                    {estateInfo.features.map((eInfo, index) => {

                        return <span key={index}>{eInfo.title}</span>

                    })}
                </div>
            </div>
        </>

     );
}

export default Estate;