
const GetEstateByFeatures = async (term) => {

    const response = await fetch('https://localhost:44380/api/GetEstateByFeatures?value=' + term,{
        method:"post"
    })
                            .then(r => r.json())
                            .then(r => {

                                return r;

                            })

                            

    return response;
  

}

export default GetEstateByFeatures;