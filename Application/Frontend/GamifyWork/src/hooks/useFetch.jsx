import { useState, useEffect } from "react";

const useFetch = (fetchFunction, dataMessage, id) => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [errorHeader, setErrorHeader] = useState(null);
  const [errorBody, setErrorBody] = useState(null);

  useEffect(() => {
    async function fetchData() {
      try {
        const data = await fetchFunction(id);
        setData(data);
        setLoading(false);
      } catch (err) {
        let errorHeader = "";
        let errorBody = "";
        if (err.response && err.response.data) {
          const { ErrorCode, Message } = err.response.data;
          errorHeader += `${ErrorCode}`;
          errorBody += `${Message}. `;
          if (ErrorCode === 500) {
            errorHeader += " - Internal Server Error";
          }
          if (ErrorCode === 404) {
            errorHeader += " - Not Found";
          }
        } else {
          errorHeader += "Unexpected error";
          errorBody += `Couldn't fetch ${dataMessage}.`;
        }

        setErrorHeader(errorHeader);
        setErrorBody(errorBody);
        setLoading(false);
      }
    }

    fetchData();
  }, [fetchFunction]);

  return { data, loading, errorHeader, errorBody };
};

export default useFetch;
