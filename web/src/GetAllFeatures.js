
const GetAllFeatures = async () => {

    const response = await fetch('https://localhost:44380/api/GetAllFeatures',{
        method:"post"
    })
                            .then(r => r.json())
                            .then(r => {

                                return r;

                            })

                            

    return response;
  

}

export default GetAllFeatures;