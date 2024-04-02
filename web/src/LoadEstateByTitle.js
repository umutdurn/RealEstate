
const LoadEstateByTitle = async (term) => {

    const response = await fetch('https://localhost:44380/api/RealEstateByTitle?title=' + term,{
        method:"post"
    })
                            .then(r => r.json())
                            .then(r => {

                                return r;

                            })

    return response.data;
  

}

export default LoadEstateByTitle;