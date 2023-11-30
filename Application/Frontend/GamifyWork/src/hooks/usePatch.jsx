const usePatch = async (patchFunction, id, dataMessage) => {
  try {
    await patchFunction(id);
  } catch (error) {
    let errorMessage = "";
    if (error.response.data != null) {
      const { Message, ErrorCode } = error.response.data;
      errorMessage += ErrorCode + " " + Message;
    } else {
      errorMessage += `failed marking ${dataMessage}`;
    }
    return { errorMessage };
  }
};

export default usePatch;
