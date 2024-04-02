
const LoadEstateRange = async (min,max) => {

    if(min == ""){

        min = "0";

    }

    if(max == ""){

        max = "0";

    }

    const response = await fetch('https://localhost:44380/api/RealEstateRangePrice?min=' + min + '&max=' + max,{
        method:"post"
    })
                            .then(r => r.json())
                            .then(r => {

                                return r;

                            })

    return response.data;
  

}

export default LoadEstateRange;