import { useState, useEffect } from "react";

const useFetch = (fetchFunction, dataMessage, fetchTrigger) => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [errorHeader, setErrorHeader] = useState(null);
  const [errorBody, setErrorBody] = useState(null);

  useEffect(() => {
    async function fetchData() {
      try {
        const data = await fetchFunction();
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
            errorBody +=
              "There is a problem with the resource you are looking for, and it cannot be displayed.";
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
